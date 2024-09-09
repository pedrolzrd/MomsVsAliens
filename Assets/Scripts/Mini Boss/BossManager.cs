using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    public static BossManager instance;

    //Colliders
    [SerializeField] GameObject leftCollider, rightCollider;


    //Cameras
    public CinemachineVirtualCamera[] cameras;

    public CinemachineVirtualCamera levelCam;
    public CinemachineVirtualCamera bossCam;

    public CinemachineVirtualCamera startCam;
    private CinemachineVirtualCamera currentCam;

    //Music
    [SerializeField] AudioSource levelMusic;
    [SerializeField] AudioSource bossMusic;

    [SerializeField] Animator spaceShip;

    void Start()
    {
        
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        
    }

    public void SwitchCamera(CinemachineVirtualCamera newCam)
    {
        currentCam = newCam;

        currentCam.Priority = 20;

        for (int i = 0; i < cameras.Length; i++)
        {
            if (cameras[i] != currentCam)
            {
                cameras[i].Priority = 10;
            }
        }
    }

    public void AscendSpaceShip()
    {
        spaceShip.Play("spaceship_ascend");
    }

    public void ActivateBossMusic()
    {
        levelMusic.Stop();
        bossMusic.Play();   
    }

    public void ActivateLevelMusic()
    {
        bossMusic.Stop();
        levelMusic.Play();
    }

    public void AtivarColliders()
    {
        leftCollider.SetActive(true);
        rightCollider.SetActive(true);
    }

    public void DesativarColliders()
    {
        leftCollider.SetActive(false);
        rightCollider.SetActive(false);
    }
}
