using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 7f;
    public float jumpForce = 15f;
    
    private Rigidbody2D rb;
    private bool isGrounded;
    float horizontalInput;
    bool isFacingRight = true;
    
    // public Transform leftFoot;
    // public Transform rightFoot;
    //
    // public float groundCheckDistance = 0.1f;
    // public LayerMask groundLayer;
    
    Animator animator;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        // CheckGrounded();
        horizontalInput = Input.GetAxis("Horizontal");

        FlipSprite();

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
            animator.SetBool("isJumping", !isGrounded);
        }
    }
    
    void FixedUpdate()
    {
        Move();
    }
    // void CheckGrounded()
    // {
    //     if (rb.linearVelocity.y <= 0.1f)
    //     {
    //         bool leftGrounded = Physics2D.Raycast(leftFoot.position, Vector2.down, groundCheckDistance, groundLayer);
    //         bool rightGrounded = Physics2D.Raycast(rightFoot.position, Vector2.down, groundCheckDistance, groundLayer);
    //         
    //         isGrounded = leftGrounded || rightGrounded;
    //         
    //         Debug.DrawRay(leftFoot.position, Vector2.down * groundCheckDistance, leftGrounded ? Color.green : Color.red);
    //         Debug.DrawRay(rightFoot.position, Vector2.down * groundCheckDistance, rightGrounded ? Color.green : Color.red);
    //     }
    //     else
    //     {
    //         isGrounded = false;
    //     }
    // }
    
    void Move()
    {
        rb.linearVelocity = new Vector2(horizontalInput * moveSpeed, rb.linearVelocity.y);
        animator.SetFloat("xVelocity", Mathf.Abs(rb.linearVelocity.x));
        animator.SetFloat("yVelocity", rb.linearVelocity.y);

    }

    void FlipSprite()
    {
        if (isFacingRight && horizontalInput < 0f || !isFacingRight && horizontalInput > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }
    
    void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        isGrounded = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isGrounded = true;
        animator.SetBool("isJumping", !isGrounded);
    }
}