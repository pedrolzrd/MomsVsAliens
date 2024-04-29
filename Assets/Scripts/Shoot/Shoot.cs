using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D _rb;

    [SerializeField]
    float _speed;

    private void Start()
    {
        _rb.velocity = transform.right * _speed;
        Destroy(this.gameObject, 5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
    }
}
