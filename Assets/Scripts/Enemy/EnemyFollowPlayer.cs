using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowPlayer : MonoBehaviour
{
    [SerializeField]
    float moveSpeed;

    GameObject player;

    bool isChasing = false;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    void Update()
    {
        if(player == null)
        
            return;

        if (isChasing)
        {
            ChasePlayer();
        }
        
        Flip();
    }

    private void ChasePlayer()
    {
        if(transform.position.x > player.transform.position.x)
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }
        if (transform.position.x < player.transform.position.x)
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("FollowTrigger"))
        {
            isChasing = true;   
        }
    }

    void Flip() //Método para virar o Sprite
    {
        if (transform.position.x > player.transform.position.x)
            transform.rotation = Quaternion.Euler(0, 180, 0);
        else
            transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
