using UnityEngine;

public class PlayerMovement : CharacterMovement
{
    public float jumpForce = 15f;
    public GunController gun;
    public bool canControl=false;
    
    private bool isGrounded;
    private bool isCrouching = false;

    float horizontalInput;

    
    
    void Update()
    {
        if (!canControl) return;

        horizontalInput = Input.GetAxis("Horizontal");
        bool crouchInput = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.C);
        bool shootInput = Input.GetMouseButtonDown(0);

        if (Input.GetButtonDown("Jump") && isGrounded && !isCrouching)
        {
            Jump();
        }
        if (crouchInput && !isCrouching)
        {
            Crouch();
        }
        else if (!crouchInput && isCrouching)
        {
            StandUp();
        }
        
        if (animator)
        {
            if (shootInput)
            {
                gun.Shoot();

                if (isCrouching)
                {
                    animator.SetBool("isShooting", false);
                    animator.SetBool("isCrouchShooting", true);
                    animator.SetBool("isCrouching", true);
                }
                else
                {
                    animator.SetBool("isShooting", true);
                    animator.SetBool("isCrouchShooting", false);
                }

            }
            else
            {
                animator.SetBool("isShooting", false);
                animator.SetBool("isCrouchShooting", false);
            }
            
        }
    }

    void FixedUpdate()
    {
        if (!isCrouching)
        {
            Move(new Vector2(horizontalInput, 0));
        }
        else
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
            if (animator)
            {
                animator.SetFloat("xVelocity", 0);
            }
        }
    }

    public void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        isGrounded = false;
        if (animator) animator.SetBool("isJumping", true);
    }
    
    public void Crouch()
    {
        isCrouching = true;
        animator.SetBool("isCrouching", true);
        gun.SetCrouching(true);
    }

    public void StandUp()
    {
        isCrouching = false;
        animator.SetBool("isCrouching", false);
        gun.SetCrouching(false);
    }   
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isGrounded = true;
        if (animator) animator.SetBool("isJumping", false);
    }
}