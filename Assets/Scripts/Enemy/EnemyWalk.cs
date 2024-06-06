using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalk : MonoBehaviour
{
    [SerializeField] 
    float spd;
    bool facingRight = true;

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
                
                facingRight = !facingRight;
                transform.Rotate(0, 180f, 0);
                spd *= -1;
            }
            else if(facingRight == false)
            {
                transform.Rotate(0, 180f, 0);
                spd *= -1;
            }
        }
    }
}
