using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;

    Vector2 move;

    Rigidbody2D rb;
    Animator animator;

    [SerializeField]
    float speed;
    [SerializeField]
    float force;
    bool isJumping;
    bool facingRight = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();  
    }

    private void Update()
    {
        Jump();

        
        
    }    

    private void FixedUpdate()
    {
        MoverPersonagemComVelocity();

        if (Input.GetAxisRaw("Horizontal") > 0 && !facingRight)
        {
            Flip();
        }
        if (Input.GetAxisRaw("Horizontal") < 0 && facingRight)
        {
            Flip();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isJumping = false;
            animator.SetBool("isJumping", false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isJumping = true;
            animator.SetBool("isJumping", true);
        }
    }

    private void Jump()
    {
        if (playerInput.actions["Jump"].triggered && isJumping == false)
        {
            rb.AddForce(new Vector2(rb.velocity.x, force));
        }
    }

    void Flip()
    {
        facingRight = !facingRight;

        transform.Rotate(0f, 180f, 0f);
    }

    void MoverPersonagemComVelocity() // Move personagem usando velocity, interage com a física, ideal para projéteis.
    {
        Vector2 input = playerInput.actions["Move"].ReadValue<Vector2>();
        move = input;
        rb.velocity = new Vector2(input.x * speed, rb.velocity.y);
        if(input.x != 0)
        {
            animator.SetBool("isRunning", true);
        }
        else if(input.x == 0)
        {
            animator.SetBool("isRunning", false);
        }
    }
}
