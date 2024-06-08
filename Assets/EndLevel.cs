using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    [SerializeField]Controller controller;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    void CallLevelEndScene()
    {
        SceneManager.LoadScene("LevelEnd");
    }
}
