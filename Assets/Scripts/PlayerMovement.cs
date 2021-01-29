using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float jumpSpeed = 5f;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float slideAnimationEndTime;
    [SerializeField] private float slidePower;
    

    private Vector2 direction = Vector2.right;
    private Rigidbody2D rigidbody;
    private bool canMove = true;
    private float startTime;
    private bool isGrounded;
    private bool isSliding;
    private float slideEndTime;

    void Start()
    {
        canMove = true;
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Move();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Slide();
        }
    }

    private void Jump()
    {
        if(isGrounded)
            rigidbody.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
    }

    private void Hit()
    {
        rigidbody.velocity = Vector2.zero;
        startTime = Time.time + 0.1f;
    }

    private void Move()
    {
        if (Time.fixedTime < startTime) return;
        if (Time.fixedTime < slideEndTime) return;

        var fraction = 1.0f - (rigidbody.velocity.x / maxSpeed);
        var force = direction * moveSpeed * fraction;
        
        rigidbody.AddForce(force, ForceMode2D.Force);
    }

    private void Slide()
    {
        slideEndTime = Time.time + slideAnimationEndTime;
        rigidbody.AddForce(Vector2.right * slidePower, ForceMode2D.Impulse);
    }
}
