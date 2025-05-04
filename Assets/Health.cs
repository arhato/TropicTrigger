using UnityEngine;

public class Health : MonoBehaviour
{
    private float maxHealth=3f;
    private float currentHealth;
    public bool isPlayer = false;
    public HealthBar healthBar;
    public GameObject gameOverMenu; 
    public GameObject infoHUD;
    public Animator animator;
    public float deathDelay = 0.25f;
    bool isDead = false;
    private Rigidbody2D rb;
    
    void Start()
    {
        currentHealth = maxHealth;
        if (healthBar != null)
        {
            healthBar.SetHealth(currentHealth, maxHealth);
        }
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    

    public void TakeDamage(float damage)
    {
        if(isDead) return;
        currentHealth = Mathf.Max(currentHealth - damage, 0);
        
        if (healthBar != null)
        {
            healthBar.SetHealth(currentHealth, maxHealth);
        }

        if (currentHealth <= 0)
        {
            isDead=true;
            Die();
        }
        else
        {
            if (animator != null)
            {
                CancelInvoke("ResetHurtTrigger");
                animator.SetTrigger("Hurt");
                if (isPlayer) SoundEffectManager.Play("Hurt");
                Invoke("ResetHurtTrigger", 0.2f);
                
            }
        }
    }
    
    void Die()
    {
        if (!isPlayer)
        {
            EnemyAI enemyAI = GetComponent<EnemyAI>();
            if (enemyAI != null)
            {
                enemyAI.enabled = false;
            }
            GunController gun = GetComponent<GunController>();
            if (gun != null)
            {
                gun.enabled = false;
            }
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
            animator.SetFloat("xVelocity",0);
            animator.SetBool("isShooting", false);
            animator.ResetTrigger("Hurt");
            animator.SetTrigger("Die");
            SoundEffectManager.Play("EnemyDeath");
        }
        else
        {
            PlayerMovement playerMovement = GetComponent<PlayerMovement>();
            if (playerMovement != null)
            {
                playerMovement.canControl = false;
            }
           
            if (gameOverMenu != null)
            {
                infoHUD.SetActive(false);
                gameOverMenu.SetActive(true);
            }
            SoundEffectManager.Play("Death");
        }
        Invoke("DestroyObject", deathDelay);
    }

    void ResetHurtTrigger()
    {
        animator.ResetTrigger("Hurt");
    }
    void DestroyObject()
    {
        Destroy(gameObject);
    }
    
}
