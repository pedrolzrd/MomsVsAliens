using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField]
    GameObject projectile;
    [SerializeField]
    Transform shootpoint;

    private GameObject player;

    [SerializeField] float enemyRateOfFire = 2 ;

    private float timer;
    public float playerRange = 4 ;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        

        float distance = Vector2.Distance(transform.position, player.transform.position);
        
        if(distance < playerRange)
        {
            timer += Time.deltaTime;

            if (timer > enemyRateOfFire)
            {
                timer = 0;
                Shoot();
            }
        }
        
    }

    void Shoot()
    {
        Instantiate(projectile, shootpoint.position, Quaternion.identity);
    }
}
