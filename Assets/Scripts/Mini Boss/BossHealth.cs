using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BossHealth : MonoBehaviour
{
    public int health = 500;

    public GameObject deathEffect;

    public bool isInvulnerable = false;

    Animator animator;

    public GameObject deadSpriteMiniBoss;

    private DamageFlash _damageFlash;

    Transform player;
    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        _damageFlash = GetComponent<DamageFlash>();
    }

    void Update()
    {

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

        //damage Flash effect
        _damageFlash.CallDamageFlash();

    }

    public void Die()
    {
        if (BossManager.instance != null)
        {
            //Parar Musica do Boss e Inicia a da Fase.
            BossManager.instance.ActivateLevelMusic();

            //Trocar para o Sprite do boss morto.   
            Instantiate(deadSpriteMiniBoss, transform.position, Quaternion.identity);

            //Liberar a Camera
            BossManager.instance.SwitchCamera(BossManager.instance.levelCam);

            //Desativar os Colliders
            BossManager.instance.DesativarColliders();

            //Da Play na Anima��o que faz a nave subir.
            BossManager.instance.AscendSpaceShip();
        }

        Destroy(gameObject);
    }

}
