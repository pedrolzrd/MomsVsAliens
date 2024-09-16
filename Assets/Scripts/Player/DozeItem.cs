using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DozeItem : MonoBehaviour
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
            playerShoot.ammoDoze += ammo;
            playerShoot.ammoMetralhadora = 0;
            playerShoot.fireRate = newRate;
            playerShoot.shoot = newShoot;
            Destroy(this.gameObject);
        }
    }
}
