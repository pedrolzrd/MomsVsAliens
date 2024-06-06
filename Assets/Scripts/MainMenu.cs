using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    [SerializeField] public TextMeshProUGUI pressStartText;

    void Start()
    {
        pressStartText.gameObject.LeanScale(new Vector3(1.2f, 1.2f), 0.9f).setLoopPingPong();
    }
}
