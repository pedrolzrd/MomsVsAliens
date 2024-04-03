using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D _rb;
    SpriteRenderer _sr;
    [SerializeField]
    GameObject _shoot;
    [SerializeField]    
    GameObject _shootPoint;
    [SerializeField]
    GameObject _respawnPoint;

    [SerializeField]
    float _speed;
    [SerializeField]
    float _force;
    [SerializeField]
    float fireRate;
    float nextShoot;
    bool _isJumping;
    bool _facingRight = true;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
        _shootPoint = transform.Find("shootpoint").gameObject;
    }

    private void Update()
    {
        Jump();
        if(Time.time >= nextShoot)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
                nextShoot = Time.time + 1f / fireRate;
            }
        }                  
    }

    private void FixedUpdate()
    {
        Movement();

        if (Input.GetAxisRaw("Horizontal") > 0 && !_facingRight)
        {
            Flip();
        }
        if (Input.GetAxisRaw("Horizontal") < 0 && _facingRight)
        {
            Flip();
        }

    }

   private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            _isJumping = false;
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            StartCoroutine(RespawnTimer());
        }
    } 

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            _isJumping = true;
        }
    }

    IEnumerator RespawnTimer()
    {
        yield return new WaitForSeconds(0.5f);
        Respawn();
    }

    void Movement()
    {
        float move = Input.GetAxis("Horizontal");

        _rb.velocity = new Vector2(_speed * move, _rb.velocity.y);
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && _isJumping == false)
        {
            _rb.AddForce(new Vector2(_rb.velocity.x, _force));
        }
    }

    void Shoot()
    {
            Instantiate(_shoot, _shootPoint.transform.position, _shootPoint.transform.rotation);       
    }

    void Flip()
    {
        _facingRight = !_facingRight;

        transform.Rotate(0f, 180f, 0f);
    }

    private void Respawn()
    {
        this.transform.position = _respawnPoint.transform.position;
    }
}
