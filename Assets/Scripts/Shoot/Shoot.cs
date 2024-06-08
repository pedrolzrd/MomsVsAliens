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

    public GameObject impactEffect; // IMPLEMENTAR

    [SerializeField]public AudioSource impactSound;

    private void Start()
    {
        _rb.velocity = transform.right * _speed;
        Destroy(this.gameObject, 5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Instantiate(impactEffect, transform.position, transform.rotation);
            impactSound.Play();
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
            impactSound.Play();
            Destroy(gameObject);
        }
        
    }

    
}
