using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] 
    private Rigidbody2D rb;
    
    [SerializeField]
    private BoxCollider2D coll;

    private float _movementDirection;
    
    [SerializeField]
    private LayerMask groundLayer;
    
    [SerializeField] 
    private float moveSpeed = 7f;
    
    [SerializeField]
    private float jumpForce = 6f;
    
    [SerializeField]
    private GameManager gameManager;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        _movementDirection = Input.GetAxisRaw("Horizontal");
        Jump();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        
        rb.linearVelocity = new Vector2(_movementDirection * moveSpeed, rb.linearVelocity.y);
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, groundLayer);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            gameManager.PlayerHitObstacle();
        }
        
        if (collision.CompareTag("Finish"))
        {
            gameManager.OnPlayerDied();
        }
    }
}
