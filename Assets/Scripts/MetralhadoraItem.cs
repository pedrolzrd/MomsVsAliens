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

    [SerializeField] public AudioSource weaponCollectSound;

    private void Start()
    {
        playerShoot = FindAnyObjectByType<PlayerShoot>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            weaponCollectSound.Play();
            playerShoot.ammoMetralhadora += ammo;
            playerShoot.fireRate = newRate;
            playerShoot.projectile = newShoot;
            Destroy(this.gameObject);   
        }
    }
}
