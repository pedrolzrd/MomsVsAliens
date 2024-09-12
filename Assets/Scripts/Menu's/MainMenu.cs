using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    [SerializeField] public Image pressStartImage;

    void Start()
    {
        pressStartImage.gameObject.LeanScale(new Vector3(1.2f, 1.2f), 0.9f).setLoopPingPong();
    }
}
