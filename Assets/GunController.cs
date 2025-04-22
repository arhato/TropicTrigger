using System.Collections;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 10f;
    public float fireRate = 0.2f;
    public int clipSize = 30;
    public float reloadTime = 1.5f;

    private float nextFireTime = 0f;
    private int currentAmmo;
    private bool isReloading = false;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        currentAmmo = clipSize;
    }

    // Call this from player or enemy script
    public void Shoot()
    {
        if (!CanShoot()) return;

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        float direction = transform.localScale.x > 0 ? 1f : -1f;
        rb.linearVelocity = new Vector2(direction * bulletSpeed, 0f);

        // Flip bullet sprite if needed
        if (direction < 0)
        {
            Vector3 bulletScale = bullet.transform.localScale;
            bulletScale.x *= -1;
            bullet.transform.localScale = bulletScale;
        }

        Destroy(bullet, 2f);

        nextFireTime = Time.time + fireRate;
        currentAmmo--;

        if (animator) animator.SetBool("isShooting", true);

        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
        }
    }

    private bool CanShoot()
    {
        return Time.time >= nextFireTime && currentAmmo > 0 && !isReloading;
    }

    private IEnumerator Reload()
    {
        
        isReloading = true;
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = clipSize;
        isReloading = false;
    }
}