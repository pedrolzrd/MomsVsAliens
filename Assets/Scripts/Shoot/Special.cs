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

    public int damage = 40;

    public GameObject enemyDeathEffect;
    private void Start()
    {
        _rb.velocity = transform.right * _speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            _animator.SetTrigger("Hit");
            Instantiate(enemyDeathEffect, collision.transform.position, collision.transform.rotation);
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Boss"))
        {
            BossHealth enemy = collision.GetComponent<BossHealth>();
            if (enemy != null)
            {
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
                _animator.SetTrigger("Hit");
                enemy.TakeDamage(damage);
            }            
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Floor"))
        {
            _animator.SetTrigger("Hit");
            Destroy(gameObject);
        }

    }


}
