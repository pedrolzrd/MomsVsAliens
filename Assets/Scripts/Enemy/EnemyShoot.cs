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

    [SerializeField]public float enemyRateOfFire = 2 ;

    private float timer;
    public float playerRange = 4 ;

    public bool canFire = true;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (canFire) {

            float distance = Vector2.Distance(transform.position, player.transform.position);

            if (distance < playerRange)
            {
                timer += Time.deltaTime;

                if (timer > enemyRateOfFire)
                {
                    timer = 0;
                    Shoot();
                }
            }
        }

        
        
    }

    void Shoot()
    {
        Instantiate(projectile, shootpoint.position, Quaternion.identity);
    }
}
