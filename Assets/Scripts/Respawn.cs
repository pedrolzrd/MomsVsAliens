using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject respawnPoint { get; private set; }
    Health health;
    [SerializeField] Transform playerTransform;

    private void Start()
    {
        health = GetComponent<Health>();
    }

    private void Update()
    {
        print(respawnPoint);        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("resPoint"))
        {
            respawnPoint = collision.gameObject;
        }
    }
}
