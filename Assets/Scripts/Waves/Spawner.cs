using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;

    [SerializeField] int maxHazardsToSpawn = 3;

    [SerializeField] float timeBetweenSpawns;
    
    private Coroutine hazardsCoroutine;
    private Coroutine checkEnemiesCoroutine;

    [SerializeField] Animator spaceshipAnimator;

    GameObject waveEnemies;

    [SerializeField] Transform spawnPoint;
    [SerializeField] GameObject portalObject;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnEnable()
    {
        hazardsCoroutine = StartCoroutine(SpawnEnemies());
        portalObject.SetActive(true);
    }

    private IEnumerator SpawnEnemies()
    {
        var hazardToSpawn = maxHazardsToSpawn;

        for (int i = 0; i < hazardToSpawn; i++)
        {   
            var hazard = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);//Cria uma instancia do inimigo.
            //Randomiza o tempo de espera para a proxima leva de hazards
            yield return new WaitForSeconds(timeBetweenSpawns); // Espera X segundospra ir pra proxima instrução sem afetar o FPS do game.
        }

        spaceshipAnimator.Play("spaceship_ascend");

        checkEnemiesCoroutine = StartCoroutine(CheckEnemies()); 

        //Startar Corrotina de Verificar Inimigos
    }

    private IEnumerator CheckEnemies()
    {
       while (true)
        {
            GameObject[] waveEnemies = GameObject.FindGameObjectsWithTag("Wave_Enemy");

            print(waveEnemies.Length);

            if(waveEnemies.Length == 0)
            {
                Debug.Log("Todos foram destruídos");

                // Mandar msg pro Wave Manager Liberar Camera
                if(WaveManager.instance != null)
                {
                    //Voltar o Follow do LevelCam pra Player
                    //WaveManager.instance.levelCam.Follow = WaveManager.instance.player.transform;

                    //Liberar a Camera
                    WaveManager.instance.SwitchCamera(WaveManager.instance.levelCam);

                    //Desativar os Colliders
                    WaveManager.instance.DesativarColliders();
                }

                break;

            }

            yield return new WaitForSeconds(2f); // Espere um segundo antes de verificar de novo.
        }
    }
}
