using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalk : MonoBehaviour
{
    [SerializeField] 
    float spd;
    bool facingRight;

    void Update()
    {
        Vector2 move = new Vector2(spd, 0); 
        transform.Translate(move * spd * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("turnCol"))
        {
            if (facingRight)
            {
                print("virou");
                facingRight = !facingRight;
                transform.Rotate(0, 180f, 0);
                spd *= -1;
            }
            else
            {
                transform.Rotate(0, 0, 0);
                spd *= -1;
            }
        }
    }
}
