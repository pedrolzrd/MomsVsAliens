using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D _rb;

    [SerializeField]
    float _speed;

    public int damage = 40;

    public GameObject impactEffect;
    public GameObject enemyDeathEffect;
    private void Start()
    {
        _rb.velocity = transform.right * _speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Instantiate(impactEffect, transform.position, transform.rotation);
            Instantiate(enemyDeathEffect, collision.transform.position, collision.transform.rotation);  
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Wave_Enemy"))
        {
            Instantiate(impactEffect, transform.position, transform.rotation);
            Instantiate(enemyDeathEffect, collision.transform.position, collision.transform.rotation);
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Boss"))
        {
            BossHealth enemy = collision.GetComponent<BossHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
            Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(gameObject);

           

        }

        if (collision.gameObject.CompareTag("FinalBoss"))
        {
            FinalBoss enemy = collision.GetComponent<FinalBoss>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
            Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }


        if (collision.gameObject.CompareTag("Floor"))
        {
            Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        
    }

    
}
