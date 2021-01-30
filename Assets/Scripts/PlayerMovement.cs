using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float jumpSpeed = 5f;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float slideAnimationEndTime = 1;
    [SerializeField] private float slidePower;

    private Vector2 direction = Vector2.right;
    private Rigidbody2D rigidbody;
    private Animator animator;
    private bool canMove = true;
    private float startTime;
    private bool isGrounded;
    private bool isSliding;
    public bool gameStarted;
    public float slideEndTime;

    private void Awake()
    {
        PlayerHealth.OnPlayerHitEvent += Hit;
        MainMenuHandler.OnGameStarted += () => gameStarted = true;
        animator = GetComponentInChildren<Animator>();
    }

    public void Stop()
    {
        canMove = false;
        rigidbody.velocity = Vector3.zero;
        this.enabled = false;
    }

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
        slideEndTime += Time.deltaTime;
        
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            Jump();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftControl))
        {
            Slide();
        }
    }

    private void Jump()
    {
       // if (isGrounded)
        {
            rigidbody.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
            animator.SetTrigger("Jump");
        }
    }

    private void Hit(int amount)
    {
        if (amount == 0)
        {
            Destroy(gameObject);
        }
        
        /*rigidbody.velocity = Vector2.zero;
        startTime = Time.time + 0.1f;*/
    }

    private void Move()
    {
        if (!gameStarted) return;
        if (Time.fixedTime < startTime) return;

        var fraction = 1.0f - (rigidbody.velocity.x / maxSpeed);
        var force = direction * moveSpeed * fraction;
        
        rigidbody.AddForce(force, ForceMode2D.Force);
    }

    private void Slide()
    {
        if (slideEndTime < slideAnimationEndTime) return;

        rigidbody.AddForce(Vector2.right * slidePower, ForceMode2D.Impulse);
        
        animator.SetTrigger("Slide");
        slideEndTime = 0;
    }
}
