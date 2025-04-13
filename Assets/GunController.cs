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
    public float delayBeforeShoot = 0.5f;

    private int currentAmmo;
    private bool canFire = true;
    private Animator animator;
    private bool isReloading = false;
    private bool isShooting;
    private bool isMouseHeld;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        isMouseHeld = Input.GetMouseButton(0);
        animator.SetBool("isShooting", isMouseHeld);

        if (Input.GetMouseButton(0) &&Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + fireRate;
            Shoot();
        }


    }
    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

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
    }

    // void Start()
    // {
    //     canFire = true;
    //     currentAmmo = clipSize;
    // }
    //
    // void Update()
    // {
    //     if (isReloading) return; 
    //
    //     if (Input.GetMouseButton(0) && canFire && currentAmmo > 0) 
    //     {
    //         canFire = false;
    //         currentAmmo--;
    //         StartCoroutine(ShootGun());
    //     }
    //     
    //     if (Input.GetKeyDown(KeyCode.R) && currentAmmo < clipSize) 
    //     {
    //         StartCoroutine(Reload());
    //     }
    // }
    //
    // IEnumerator ShootGun()
    // {
    //     yield return new WaitForSeconds(fireRate);
    //     canFire = true;
    //     Shoot();
    //
    //     if (currentAmmo <= 0) 
    //     {
    //         StartCoroutine(Reload());
    //     }
    // }
    //
    // void Shoot()
    // {
    //     GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    //     Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
    //     rb.linearVelocity = firePoint.forward * bulletSpeed;
    //     Destroy(bullet, 2f);
    // }
    //
    // IEnumerator Reload()
    // {
    //     isReloading = true;
    //     Debug.Log("Reloading...");
    //     yield return new WaitForSeconds(reloadTime);
    //
    //     currentAmmo = clipSize; // Fully reload the magazine
    //     isReloading = false;
    //     Debug.Log("Reload Complete");
    // }
}