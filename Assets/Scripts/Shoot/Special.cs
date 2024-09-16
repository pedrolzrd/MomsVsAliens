using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Special : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D _rb;
    [SerializeField]
    Animator _animator;

    [SerializeField]
    float _speed;

    public int damage = 100;

    public GameObject enemyDeathEffect;

    public GameObject impactEffect;

    private void Start()
    {
        _rb.velocity = transform.right * _speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Instantiate(impactEffect, transform.position, transform.rotation);
            _animator.SetTrigger("Hit");
            Instantiate(enemyDeathEffect, collision.transform.position, collision.transform.rotation);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Wave_Enemy"))
        {
            Instantiate(impactEffect, transform.position, transform.rotation);
            _animator.SetTrigger("Hit");
            Instantiate(enemyDeathEffect, collision.transform.position, collision.transform.rotation);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Boss"))
        {
            BossHealth enemy = collision.GetComponent<BossHealth>();
            if (enemy != null)
            {
                Instantiate(impactEffect, transform.position, transform.rotation);
                _animator.SetTrigger("Hit");
                enemy.TakeDamage(damage);
            }            
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("FinalBoss"))
        {
            FinalBoss enemy = collision.GetComponent<FinalBoss>();
            if (enemy != null)
            {
                Instantiate(impactEffect, transform.position, transform.rotation);
                _animator.SetTrigger("Hit");
                enemy.TakeDamage(damage);
            }            
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Floor"))
        {
            Instantiate(impactEffect, transform.position, transform.rotation);
            _animator.SetTrigger("Hit");
            Destroy(gameObject);
        }

    }


}
