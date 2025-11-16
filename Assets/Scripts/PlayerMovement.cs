using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float acceleration = 10f;
    public float jumpForce = 7f;
    public float minJumpForce = 3f; // Fuerza mínima del salto
    public float jumpCutMultiplier = 0.5f; // Multiplicador cuando se suelta la tecla
    public Transform groundCheck;
    public float groundCheckRadius = 0.1f;
    public LayerMask groundLayer;
    public ParticleSystem dustEffect;
    public Transform dustEmitter;
    
    private Rigidbody2D rb;
    private float moveInput;
    private bool isGrounded;
    private bool isJumping; // Controla si está en medio de un salto
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer) != null;
        
        // Iniciar salto
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isJumping = true;
            JumpDust();
        }
        
        // Si se suelta la tecla de salto mientras está subiendo
        if (Input.GetKeyUp(KeyCode.Space) && isJumping && rb.velocity.y > 0)
        {
            // Reduce la velocidad vertical para cortar el salto
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * jumpCutMultiplier);
            isJumping = false;
        }
        
        // Resetear el estado de salto cuando toca el suelo
        if (isGrounded && rb.velocity.y <= 0)
        {
            isJumping = false;
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
        
        bool isWalking = Mathf.Abs(moveInput) > 0.1f && isGrounded;
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