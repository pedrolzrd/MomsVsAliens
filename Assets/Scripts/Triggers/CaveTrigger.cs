using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveTrigger : MonoBehaviour
{
    [SerializeField] AudioSource LevelMusic;
    [SerializeField] AudioSource CaveMusic;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")){
            //Trocar Musica.
            LevelMusic.Stop();  
            CaveMusic.Play();

            //Trocar Camera
            WaveManager.instance.SwitchCamera(WaveManager.instance.caveCam);

        }
    }
}
