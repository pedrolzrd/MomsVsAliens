using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveTrigger : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera levelCam;
    [SerializeField] GameObject rightSpawner, leftSpawner;
    [SerializeField] Animator spaceShip;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")){

            if (WaveManager.instance != null)
            {
                //Tirar O follow do LevelCam
                //WaveManager.instance.levelCam.Follow = null;

                //Transicionar para Wave Cam
                WaveManager.instance.SwitchCamera(WaveManager.instance.waveCam);

                

                //Ativar os Colliders para o player nao sair da tela.
                WaveManager.instance.AtivarColliders();

                //
            }

            //Dar play na animação de Surgir da Nave.
            spaceShip.Play("spaceship_descend");

            //Desativar o Trigger
            gameObject.SetActive(false);
        }
    }
}
