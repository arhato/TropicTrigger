using UnityEngine;

public class PlayerMovement : CharacterMovement
{
    public float jumpForce = 15f;
    public GunController gun;
    public bool canControl = false;

    private bool isGrounded;
    float horizontalInput;

    void Update()
    {
        if (!canControl) return;

        horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }

        if (Input.GetMouseButton(0))
        {
            gun.Shoot();
            if (animator) animator.SetBool("isShooting", true);
        }
        else
        {
            if (animator) animator.SetBool("isShooting", false);
        }
    }

    void FixedUpdate()
    {
        Move(new Vector2(horizontalInput, 0));
    }

    public void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        isGrounded = false;
        if (animator) animator.SetBool("isJumping", true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isGrounded = true;
        if (animator) animator.SetBool("isJumping", false);
    }
}