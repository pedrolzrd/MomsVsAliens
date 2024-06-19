using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class BossTrigger : MonoBehaviour
{
    [SerializeField]GameObject boss;
    [SerializeField]Animator bossAnimator;

    [SerializeField]public VirtualCam cam;

    [SerializeField]public Vector3 bossPosition = new Vector3(253.5f, 10.11f, -10f);


    [SerializeField] AudioSource bossMusic;
    [SerializeField] AudioSource levelMusic;


    [SerializeField] GameObject barrierLeft;
    [SerializeField] GameObject barrierRight;


    void Start()
    {
        //boss = GameObject.FindGameObjectWithTag("Boss");
        //bossAnimator = boss.GetComponent<Animator>();
        
        
    }

    

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            levelMusic.Stop();
            bossMusic.Play();
            barrierLeft.SetActive(true);
            barrierRight.SetActive(true);
            cam.transform.position = bossPosition;
            cam.vCam.Follow = null;
            bossAnimator.enabled = true;
            Destroy(gameObject);
        }
    }
}
