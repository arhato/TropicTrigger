using System;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
     private bool hit;
     private PolygonCollider2D collider;
     private Animator animator;
     private Rigidbody2D rb;
    void Start()
    {
        animator = GetComponent<Animator>();
        collider = GetComponent<PolygonCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (hit) return;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Bullet hit:"+other.gameObject.name);
        
        Health health = other.GetComponent<Health>();
        if (health != null)
        {
            health.TakeDamage(1);
        }
        hit = true;
        collider.enabled = false;
        rb.linearVelocity = Vector2.zero;
        rb.bodyType = RigidbodyType2D.Kinematic;
        animator.SetTrigger("hit");
    }

    private void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
