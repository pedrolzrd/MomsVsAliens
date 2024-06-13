using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField]
    GameObject shoot;
    [SerializeField]
    GameObject shootpoint;
    void Start()
    {
        StartCoroutine(Shoot());
    }

    IEnumerator Shoot()
    {
        Instantiate(shoot, shootpoint.transform.position, shootpoint.transform.rotation);
        yield return new WaitForSeconds(2f);
        StartCoroutine(Shoot());
    }
}
