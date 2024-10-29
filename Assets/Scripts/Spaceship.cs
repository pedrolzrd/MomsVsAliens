using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject forceFieldEffect;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("chinelo")){
            Instantiate(forceFieldEffect, collision.transform.position, Quaternion.Euler(0,0,-90));
        }
    }
}
