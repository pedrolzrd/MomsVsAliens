using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpdetect : MonoBehaviour
{
    [SerializeField]
    PlayerMovement player;

    private void Update()
    {
        print(player.isJumping);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Floor"))
        {
            player.isJumping = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Floor"))
        {
            player.isJumping = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Floor"))
        {
            player.isJumping = true;
        }
    }
}
