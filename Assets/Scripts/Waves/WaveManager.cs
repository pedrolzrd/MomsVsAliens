using Cinemachine;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public static WaveManager instance;

    GameObject waveEnemies;

    public CinemachineVirtualCamera[] cameras;

    [Header("Cameras")]
    public CinemachineVirtualCamera levelCam;
    public CinemachineVirtualCamera waveCam;
    public CinemachineVirtualCamera caveCam;
    public CinemachineVirtualCamera finalBossCam;

    public CinemachineVirtualCamera startCam;
    private CinemachineVirtualCamera currentCam;

    [Header("Colliders")]
    [SerializeField] GameObject leftCollider; 
    [SerializeField] GameObject rightCollider;
    [HideInInspector]public GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        currentCam = startCam;

        for (int i = 0; i < cameras.Length; i++)
        {
            if (cameras[i] == currentCam)
            {
                cameras[i].Priority = 20;
            }
            else
            {
                cameras[i].Priority = 10;
            }
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

        } else
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

        for (int i = 0;i < cameras.Length;i++)
        {
            if(cameras[i] != currentCam)
            {
                cameras[i].Priority = 10;
            }
        }
    }

    //Colliders
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
