using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressStart : MonoBehaviour
{
public GameObject menuSelectPlayer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


 public void OpenMenuSelectPlayer()
    {
        menuSelectPlayer.SetActive(true);
    }


}
