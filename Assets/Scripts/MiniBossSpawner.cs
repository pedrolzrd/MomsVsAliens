using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBossSpawner : MonoBehaviour
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


        //Startar Corrotina de Verificar Inimigos
    }       
}
