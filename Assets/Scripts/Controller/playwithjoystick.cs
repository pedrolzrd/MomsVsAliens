using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playwithjoystick : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            SceneManager.LoadScene("Selector");
        }
    }
}
