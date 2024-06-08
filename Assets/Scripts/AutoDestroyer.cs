using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroyer : MonoBehaviour
{
    public float delay;

    public void Start()
    {
        Destroy(gameObject, delay);

    }
}
