using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 7f;
    public float jumpForce = 15f;
    
    private Rigidbody2D rb;
    private bool isGrounded;
    
    public Transform leftFoot;
    public Transform rightFoot;
    
    public float groundCheckDistance = 0.1f;
    public LayerMask groundLayer;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
    }
    
    void Update()
    {
        CheckGrounded();
        
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }
        
        Move();
    }
    
    void CheckGrounded()
    {
        if (rb.linearVelocity.y <= 0.1f)
        {
            bool leftGrounded = Physics2D.Raycast(leftFoot.position, Vector2.down, groundCheckDistance, groundLayer);
            bool rightGrounded = Physics2D.Raycast(rightFoot.position, Vector2.down, groundCheckDistance, groundLayer);
            
            isGrounded = leftGrounded || rightGrounded;
            
            Debug.DrawRay(leftFoot.position, Vector2.down * groundCheckDistance, leftGrounded ? Color.green : Color.red);
            Debug.DrawRay(rightFoot.position, Vector2.down * groundCheckDistance, rightGrounded ? Color.green : Color.red);
        }
        else
        {
            isGrounded = false;
        }
    }
    
    void Move()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
    }
    
    void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
    }
}