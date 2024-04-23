using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class VirtualCam : MonoBehaviour
{
    [SerializeField]public CinemachineVirtualCamera vCam;
    void Start()
    {
        vCam = GetComponent<CinemachineVirtualCamera>();
        vCam.Follow = GameObject.FindWithTag("Player").transform;

    }
    void Update()
    {
        
    }
}
