using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossTrigger : MonoBehaviour
{

    [SerializeField] AudioSource LevelMusic;
    [SerializeField] AudioSource BossMusic;

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

            //Trocar Musica.
            LevelMusic.Stop();
            BossMusic.Play();

            WaveManager.instance.SwitchCamera(WaveManager.instance.finalBossCam);

            Destroy(gameObject);
        }
    }
}
