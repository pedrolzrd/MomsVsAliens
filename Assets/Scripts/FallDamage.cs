using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDamage : MonoBehaviour
{
    [SerializeField]public Health playerHealth;
    [SerializeField] public Transform returnpoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerHealth.TakeDamage(1);
            collision.transform.position = returnpoint.transform.position;
        }
    }
}
