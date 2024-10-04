using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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
    [SerializeField] public PlayerShoot playerShoot;
    [SerializeField] PlayerInput playerInput;

    private DamageFlash _damageFlash;

    Animator animator;
    [SerializeField]EnemyShoot enemyShoot;

    [SerializeField]GameObject explosionPrefab;

    [SerializeField]Sprite damagedSprite;



    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
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
            //GetComponent<Animator>().SetBool("phase2", true); PARA O NEXT
            animator.SetBool("damaged", true);
            enemyShoot.enemyRateOfFire = 1f;
            



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

        //Start Coroutine de Spawnar Explosoes
        StartCoroutine(ExplosionsCoroutine());

        enemyShoot.canFire = false;

        //TOCAR animação da Nave indo embora.
        animator.SetBool("dead", true);




        barrierLeft.SetActive(false);
        barrierRight.SetActive(false);

        //playerMovement.speed = 0;

        playerInput.currentActionMap = null;

        playerShoot.canShoot = false;

        cutscene.SetActive(true);
    }

    IEnumerator ExplosionsCoroutine()
    {
        Instantiate(explosionPrefab, transform.position + new Vector3(0,1,0), Quaternion.identity);  
        yield return new WaitForSeconds(1f);

        Instantiate(explosionPrefab, transform.position + new Vector3(0.4f, 1.5f, 0), Quaternion.identity);
        yield return new WaitForSeconds(1f);

        Instantiate(explosionPrefab, transform.position + new Vector3(1, -1.3f, 0), Quaternion.identity);
        yield return new WaitForSeconds(1f);

        Instantiate(explosionPrefab, transform.position + new Vector3(0.2f, 1.3f, 0), Quaternion.identity);
        yield return new WaitForSeconds(1f);

        Instantiate(explosionPrefab, transform.position + new Vector3(0.8f, 1, 0), Quaternion.identity);

    }
}
