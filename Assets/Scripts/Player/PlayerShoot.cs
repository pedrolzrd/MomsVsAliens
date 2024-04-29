using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    GameObject shoot;
    [SerializeField]
    Transform shootPoint;

    [SerializeField]
    float fireRate;
    float nextShoot;

    void Update()
    {
        if(!PauseMenu.isPaused)
        {
            if (Time.time >= nextShoot)
            {
                if (Input.GetButtonDown("Fire3"))
                {
                    Shoot();
                    nextShoot = Time.time + 1f / fireRate;
                }
            }
        }
        
    }

    void Shoot()
    {
        Instantiate(shoot, shootPoint.position, shootPoint.rotation);
    }
}
