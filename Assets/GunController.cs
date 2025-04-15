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
        if (Time.timeScale == 0f) return;

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
}