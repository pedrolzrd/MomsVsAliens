using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveTrigger : MonoBehaviour
{
    [SerializeField] GameObject levelCam;
    [SerializeField] GameObject caveCam;
    [SerializeField] AudioSource LevelMusic;
    [SerializeField] AudioSource CaveMusic;

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")){
            //Trocar Musica.
            LevelMusic.Stop();  
            CaveMusic.Play();
            //Trocar Camera Confiner _se poss�vel.

            levelCam.SetActive(false);  
            caveCam.SetActive(true);

            Destroy(gameObject);


        }
    }
}
