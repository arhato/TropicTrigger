using UnityEngine;

public class EnemyAI : CharacterMovement
{
    public Transform player;
    [SerializeField] private float detectionRange = 10f;
    [SerializeField] private float shootingRange = 8f;
    public GunController gun;
    private float fallThreshold = -10f;
    public float damageCooldown = 1f;
    private float lastDamageTime = -999f;

    protected override void Start()
    {
        base.Start();
        moveSpeed = 1f;
    }
    private void Update()
    {
        if (transform.position.y < fallThreshold)
        {
            Destroy(gameObject); 
            return; 
        }
        
        float distance = Vector2.Distance(transform.position, player.position);
        Vector2 dir = player.position.x < transform.position.x ? Vector2.left : Vector2.right;
        transform.localScale = new Vector3(Mathf.Sign(dir.x) * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        
        if (distance < shootingRange)
        {
            animator.SetBool("isShooting", true);
            gun.Shoot();
            animator.SetFloat("xVelocity", 0f);
        }
        else if (distance < detectionRange)
        {
            Move(dir);
            animator.SetBool("isShooting", false);
        }
        else
        {
            animator.SetBool("isShooting", false);
            animator.SetFloat("xVelocity", 0f);
        }
    }
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRange);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!CompareTag("Enemy")) return;
        if (collision.CompareTag("Player") && Time.time - lastDamageTime > damageCooldown)
        {
            Health playerHealth = collision.GetComponent<Health>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(1);
                lastDamageTime = Time.time;
            }
        }
    }
}