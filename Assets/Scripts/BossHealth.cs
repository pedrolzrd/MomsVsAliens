using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int health = 500;

    public GameObject deathEffect;

    public bool isInvulnerable = false;

    [SerializeField] public VirtualCam cam;

    Transform player;

    [SerializeField] AudioSource levelMusic;
    [SerializeField] AudioSource bossMusic;

    [SerializeField]GameObject barrierLeft;
    [SerializeField]GameObject barrierRight;    

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void TakeDamage(int damage)
    {
        if (isInvulnerable)
        {
            return;
        }

        health -= damage;

        if(health <= 200 )
        {
            GetComponent<Animator>().SetBool("isEnraged", true);
        }

        if(health <= 0)
        {
            Die();
        }

    }

    void Die()
    {
        bossMusic.Stop();
        levelMusic.Play();  
        Instantiate(deathEffect);
        barrierLeft.SetActive(false);   
        barrierRight.SetActive(false);
        cam.vCam.Follow = player;
        Destroy(gameObject);
    }


    

    void Update()
    {
        
    }
}
