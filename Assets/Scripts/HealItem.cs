using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealItem : MonoBehaviour
{
    [SerializeField]public Health playerHealth;

    public int heal = 1;

    public GameObject healAnimation;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (playerHealth.currentHealth <= playerHealth.maxHealth)
            {
                playerHealth.RecoverHealthAndLife();
                Instantiate(healAnimation, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}
