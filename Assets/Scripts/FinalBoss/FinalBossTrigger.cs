using Cinemachine;
using UnityEngine;

public class FinalBossTrigger : MonoBehaviour
{

    [SerializeField] AudioSource LevelMusic;
    [SerializeField] AudioSource BossMusic;

    [SerializeField] GameObject rightCollider;
    [SerializeField] GameObject leftCollider;

    [SerializeField] Animator spaceShip;

    [SerializeField]CinemachineVirtualCamera levelCam;
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

            //Ativar os Colliders 
            rightCollider.SetActive(true);
            leftCollider.SetActive(true);

            levelCam.Follow = null;

            //Dar play na animação de Surgir da Nave.
            spaceShip.Play("spaceship_descend_finalBoss");


        }
    }
}
