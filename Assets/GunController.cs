using System.Collections;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject bulletPrefab;
    private Transform firePoint;
    public Transform standingFirePoint;
    public Transform crouchingFirePoint;
    public float bulletSpeed = 10f;
    public float fireRate = 0.2f;
    public int clipSize = 30;
    public float reloadTime = 1.5f;
    public bool isEnemyGun = false;
    
    private float nextFireTime = 0f;
    private int currentAmmo;
    private bool isReloading = false;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        currentAmmo = clipSize;
        firePoint = standingFirePoint;
    }

    public void Shoot()
    {
        if (isReloading || currentAmmo <= 0)
        {
            if (!isEnemyGun)
            {
                SoundEffectManager.Play("EmptyGun");
            }
            return;
        }
            
        if (!CanShoot())
        {
            return;
        }
             
        if (!isEnemyGun)
        {
            SoundEffectManager.Play("Shoot");
        }
            
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        ProjectileManager projectile= bullet.GetComponent<ProjectileManager>();
        if (projectile != null)
        {
            projectile.sourceTag=isEnemyGun ? "Enemy" : "Player";
        }
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        float direction = transform.localScale.x > 0 ? 1f : -1f;
        rb.linearVelocity = new Vector2(direction * bulletSpeed, 0f);

        if (direction < 0)
        {
            Vector3 bulletScale = bullet.transform.localScale;
            bulletScale.x *= -1;
            bullet.transform.localScale = bulletScale;
        }

        Destroy(bullet, 2f);

        nextFireTime = Time.time + fireRate;
        currentAmmo--;
            
        if (animator && !isReloading) 
        {
            animator.SetBool("isShooting", true);
            StartCoroutine(ResetShootingAnimation());
        }
            
        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
        }
    }

    private bool CanShoot()
    {
        return Time.time >= nextFireTime && currentAmmo > 0 && !isReloading;
    }

    public void SetCrouching(bool crouching)
    {
        firePoint = crouching ? crouchingFirePoint : standingFirePoint;
    }
    private IEnumerator Reload()
    {
        isReloading = true;
        if (animator) animator.SetBool("isShooting", false);
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = clipSize;
        isReloading = false;
    }
        
    private IEnumerator ResetShootingAnimation()
    {
        yield return new WaitForSeconds(0.1f);
        if (animator) animator.SetBool("isShooting", false);
    }
        
    public int GetCurrentAmmo()
    {
        return currentAmmo;
    }

    public bool IsReloading()
    {
        return isReloading;
    }
}