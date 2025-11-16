using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float acceleration = 10f;
    public float jumpForce = 7f;

    public Transform groundCheck;
    public float groundCheckRadius = 0.1f;
    public LayerMask groundLayer;

    public ParticleSystem dustEffect;
    public Transform dustEmitter;

    private Rigidbody2D rb;
    private float moveInput;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer) != null;

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            JumpDust();

        }
    }

    void FixedUpdate()
    {
        float targetVelocityX = moveInput * moveSpeed;
        float smoothedVelocityX = Mathf.Lerp(rb.velocity.x, targetVelocityX, acceleration * Time.fixedDeltaTime);
        rb.velocity = new Vector2(smoothedVelocityX, rb.velocity.y);

        if (Mathf.Abs(moveInput) > 0.1f && isGrounded)
        {
            StepDust();
            

        }
        bool isWalking = Mathf.Abs(moveInput) > 0.1f || Mathf.Abs(moveInput) < -0.1f && isGrounded;
        GetComponent<Animator>().SetBool("walking", isWalking);

        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        if (moveInput > 0.1f)
        {
            sprite.flipX = false; // Facing right
        }
        else if (moveInput < -0.1f)
        {
            sprite.flipX = true; // Facing left
        }

    }

    void StepDust()
    {
        if (dustEffect == null) return;

        dustEmitter.position = new Vector3(transform.position.x, transform.position.y - 0.5f, 0);
        dustEffect.Play();
    }

    void JumpDust()
    {
        if (dustEffect == null) return;

        dustEmitter.position = new Vector3(transform.position.x, transform.position.y - 0.4f, 0);
        dustEffect.Play();
    }
}
