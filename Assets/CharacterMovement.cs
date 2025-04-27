using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 7f;
    protected Rigidbody2D rb;
    protected Animator animator;
    protected bool isFacingRight = true;
    
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        rb.freezeRotation = true;
    }

    public void Move(Vector2 direction)
    {
        rb.linearVelocity = new Vector2(direction.x * moveSpeed, rb.linearVelocity.y);
        Flip(direction.x);

        if (animator)
        {
            animator.SetFloat("xVelocity", Mathf.Abs(rb.linearVelocity.x));
            animator.SetFloat("yVelocity", rb.linearVelocity.y);
        }
    }

    void Flip(float x)
    {
        if ((x > 0 && !isFacingRight) || (x < 0 && isFacingRight))
        {
            isFacingRight = !isFacingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }
}