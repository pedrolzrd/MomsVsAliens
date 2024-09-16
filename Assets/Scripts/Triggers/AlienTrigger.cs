using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienTrigger : MonoBehaviour
{
    [SerializeField] GameObject[] aliens;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            for (int i = 0; i < aliens.Length; i++)
            {
                aliens[i].SetActive(true);
            }
        }
    }
}
