using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class BossTrigger : MonoBehaviour
{

    [SerializeField]public VirtualCam cam;

    [SerializeField]public Vector3 bossPosition = new Vector3(253.5f, 10.11f, -10f);


    [SerializeField] AudioSource bossMusic;
    [SerializeField] AudioSource levelMusic;


    [SerializeField] GameObject barrierLeft;
    [SerializeField] GameObject barrierRight;

    [SerializeField] Animator spaceShip;


    void Start()
    {

    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Da Play na Musica do Boss
            BossManager.instance.ActivateBossMusic();

            //Transicionar para Boss Cam
            BossManager.instance.SwitchCamera(BossManager.instance.bossCam);

            //Ativa os Colliders pro player n fugir.
            BossManager.instance.AtivarColliders();

            //Ativa a animação da Nave.
            spaceShip.Play("spaceship_descend");

            //Destroi esse Trigger
            Destroy(gameObject);
        }
    }
}
