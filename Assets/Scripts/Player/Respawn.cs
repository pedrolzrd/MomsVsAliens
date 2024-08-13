using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Transform respawnPoint; //{ get; private set; }
    Health health;
    [SerializeField] Transform playerTransform;

    private void Start()
    {
        health = GetComponent<Health>();   
        playerTransform = GetComponent<Transform>();
    }

    private void Update()
    {
        print(respawnPoint);
        if (Input.GetKeyDown(KeyCode.R))
        {            
            playerTransform.position = respawnPoint.position;
        } 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("resPoint"))
        {
            respawnPoint = collision.gameObject.transform;
        }
    }

    public void RespawnPlayer()
    {
        playerTransform.position = respawnPoint.position;
    }
}
