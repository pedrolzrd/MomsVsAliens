using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameObject music;
    void Start()
    {
        music = GameObject.FindGameObjectWithTag("Music");
        Destroy(music);
    }


    void Update()
    {
        
    }
}
