using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBoss : MonoBehaviour
{
    public int health = 90;

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

    private DamageFlash _damageFlash;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        _damageFlash = GetComponent<DamageFlash>(); 
    }

    public void TakeDamage(int damage)
    {
        if (isInvulnerable)
        {
            return;
        }

        health -= damage;

        if (health <= 60)
        {
            GetComponent<Animator>().SetBool("phase2", true);
        }

        if (health <= 0)
        {
            Die();
        }

        //damage Flash effect
        _damageFlash.CallDamageFlash();

    }

    void Die()
    {
        bossMusic.Stop();
        victoryMusic.Play();
        barrierLeft.SetActive(false);
        barrierRight.SetActive(false);

        playerMovement.speed = 0;
        cutscene.SetActive(true);
        Destroy(gameObject);
    }


    void Update()
    {

    }
}
