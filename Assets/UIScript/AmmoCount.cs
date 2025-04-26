using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AmmoCount : MonoBehaviour
{
    public TextMeshProUGUI ammoText;  
    public GunController gunController;
    
    public Color normalColor = Color.white;
    public Color lowAmmoColor = Color.red;
    public int lowAmmoThreshold = 5; 
    
    private int maxAmmo;
    private int currentAmmo;
    
    void Start()
    {
        if (gunController == null)
        {
            return;
        }
        
        if (ammoText == null)
        {
            return;
        }
        
        maxAmmo = gunController.clipSize;
        UpdateAmmoDisplay();
    }
    
    void Update()
    {
        UpdateAmmoDisplay();
    }
    
    public void UpdateAmmoDisplay()
    {
        if (gunController == null || ammoText == null) return;
        
        bool isReloading = gunController.IsReloading();
        
        if (isReloading)
        {
            ammoText.text="RELOADING";
        }
        else
        {
            currentAmmo = gunController.GetCurrentAmmo();
            ammoText.text = currentAmmo + "/" + maxAmmo;
        }

        if (currentAmmo <= lowAmmoThreshold)
        {
            ammoText.color = lowAmmoColor;
        }
        else
        {
            ammoText.color = normalColor;
        }
    }
}