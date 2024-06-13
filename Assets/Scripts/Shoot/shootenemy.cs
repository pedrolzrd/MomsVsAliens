using System.Collections;
using System.Collections.Generic;
using UnityEditor.Hardware;
using UnityEngine;

public class shootenemy : MonoBehaviour
{
    [SerializeField]
    float spd;
    Health health;
    [SerializeField]
    int damage;

    private void Start()
    {
        health = FindObjectOfType<Health>();
    }

    private void Update()
    {
        transform.Translate(transform.position * spd * Time.deltaTime);
        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            health.TakeDamage(damage);
        }
    }
}
