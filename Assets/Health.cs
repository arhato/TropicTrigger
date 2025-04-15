using UnityEngine;

public class Health : MonoBehaviour
{
    private float maxHealth=3f;
    private float currentHealth;
    
    public HealthBar healthBar;
    void Start()
    {
        currentHealth = maxHealth;
        if (healthBar != null)
        {
            healthBar.SetHealth(currentHealth, maxHealth);
        }
    }

    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        currentHealth = Mathf.Max(currentHealth - damage, 0);
        
        if (healthBar != null)
        {
            healthBar.SetHealth(currentHealth, maxHealth);
        }

        if (currentHealth <= 0)
        {
            //dead
            Destroy(gameObject);
        }
        else
        {
            //hurt
        }
    }
}
