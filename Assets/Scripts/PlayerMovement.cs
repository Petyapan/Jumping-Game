using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] 
    private Rigidbody2D rb;
    
    [SerializeField]
    BoxCollider2D coll;

    private float direction = 0f;
    
    [SerializeField]
    private LayerMask groundLayer;
    
    [SerializeField] 
    private float moveSpeed = 7f;
    
    [SerializeField]
    private float jumpForce = 6f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        direction = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(direction * moveSpeed, rb.linearVelocity.y);
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, groundLayer);
    }
}
