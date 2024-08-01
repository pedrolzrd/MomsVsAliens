using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBoss : MonoBehaviour
{
    public int health = 500;

    public GameObject deathEffect;

    public bool isInvulnerable = false;

    [SerializeField] public VirtualCam cam;

    Transform player;

    [SerializeField] AudioSource victoryMusic;
    [SerializeField] AudioSource bossMusic;

    [SerializeField] GameObject barrierLeft;
    [SerializeField] GameObject barrierRight;

    [SerializeField] GameObject cutscene;

    [SerializeField] public PlayerMovement playerMovement;

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

        if (health <= 200)
        {
            GetComponent<Animator>().SetBool("isEnraged", true);
        }

        if (health <= 0)
        {
            Die();
        }

    }

    void Die()
    {
        bossMusic.Stop();
        victoryMusic.Play();
        Instantiate(deathEffect);
        barrierLeft.SetActive(false);
        barrierRight.SetActive(false);
        cam.vCam.Follow = player;
        playerMovement.speed = 0;
        cutscene.SetActive(true);
        Destroy(gameObject);
    }




    void Update()
    {

    }
}
