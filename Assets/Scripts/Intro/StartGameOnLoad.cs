using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameOnLoad : MonoBehaviour
{
    void OnEnable()
    {
        SceneManager.LoadScene("Game");
    }
}
