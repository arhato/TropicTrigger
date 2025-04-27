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
    public float deathDelay = 0f;
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

    void Update()
    {
        
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
                animator.SetTrigger("Hurt");
                Invoke("ResetHurtTrigger", 0.1f);
            }
        }
    }
    
    void Die()
    {
        if (animator != null && !isPlayer)
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
            animator.SetFloat("xVelocity",0);
            animator.SetBool("isShooting", false);
            animator.SetTrigger("Die");
        }

        if (isPlayer)
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
