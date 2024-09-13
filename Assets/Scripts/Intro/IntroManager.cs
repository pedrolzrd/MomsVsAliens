using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    GameObject music;
    void Start()
    {
        music = GameObject.FindGameObjectWithTag("Music");
        Destroy(music);
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            SceneManager.LoadScene("Game");
        }
    }
}
