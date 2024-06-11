using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroManager : MonoBehaviour
{
    GameObject music;
    void Start()
    {
        music = GameObject.FindGameObjectWithTag("Music");
        Destroy(music);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
