using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class MetralhadoraItem : MonoBehaviour
{
    PlayerShoot playerShoot;
    [SerializeField]
    GameObject newShoot;
    [SerializeField]
    float newRate;
    [SerializeField]
    int ammo;

    private void Start()
    {
        playerShoot = FindAnyObjectByType<PlayerShoot>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerShoot.ammoMetralhadora += ammo;
            playerShoot.ammoDoze = 0;
            playerShoot.fireRate = newRate;
            playerShoot.shoot = newShoot;
            Destroy(this.gameObject);   
        }
    }
}
