using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;

    Vector2 move;

    Rigidbody2D rb;
    Animator animator;

    [SerializeField] public float speed;
    [SerializeField] public float normalSpeed;
    [SerializeField] public float force;
    public bool isJumping;
    bool isFacingRight = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerInput = GetComponent<PlayerInput>();

        normalSpeed = speed;
    }

    private void Update()
    {
        Jump();

        if (move.x > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (move.x < 0 && isFacingRight)
        {
            Flip();
        }


        if (Mathf.Abs(move.x) != 0)
        {
            animator.SetBool("isRunning", true);
        }
        else 
        {
            animator.SetBool("isRunning", false);
        }
    }    

    private void FixedUpdate()
    {
        MoverPersonagemComVelocity();        
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
        isFacingRight = !isFacingRight;

        transform.Rotate(0f, 180f, 0f);
    }

    void MoverPersonagemComVelocity() // Move personagem usando velocity, interage com a física, ideal para projéteis.
    {
        Vector2 input = playerInput.actions["Move"].ReadValue<Vector2>();
        move = input;
        rb.velocity = new Vector2(input.x * speed, rb.velocity.y);
        
    }
}
