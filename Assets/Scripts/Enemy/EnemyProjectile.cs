using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField]
    float force;
    Health health;
    [SerializeField]
    int damage;

    SpriteRenderer sR;

    [SerializeField] public GameObject impactEffect;

    private Rigidbody2D rb;

    private GameObject player;

    private float yOffset = 0.8f;

    bool isFacingRight = true;

    private void Start()
    {
        sR = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        health = FindObjectOfType<Health>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2 (direction.x, direction.y + yOffset).normalized * force;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot);

        if (direction.x > 0 /*&& !isFacingRight*/)
        {
            Flip();
            
        }
        else if (direction.x < 0 /*&& isFacingRight */)
        {
            Flip();
            
        }
    }

    private void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            health.TakeDamage(damage);
            Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Floor"))
        {
            Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;

        transform.Rotate(0f, 180f, 0f);


    }
}
