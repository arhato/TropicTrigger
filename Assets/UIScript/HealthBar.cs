using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image[] healthImages;

    public void SetHealth(float currentHealth, float maxHealth)
    {
        int fullHearts = Mathf.FloorToInt(currentHealth);
        
        for (int i = 0; i < healthImages.Length; i++)
        {
            healthImages[i].enabled = i < fullHearts;
        }
    }
}
