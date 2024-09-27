using UnityEngine;

public class CityTrigger : MonoBehaviour
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
            LevelMusic.Play();
            CaveMusic.Stop();

            //Trocar Camera
            WaveManager.instance.SwitchCamera(WaveManager.instance.levelCam);

       

            Destroy(gameObject);
        }   
    }
}
