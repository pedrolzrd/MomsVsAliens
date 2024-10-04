using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class IntroManager : MonoBehaviour
{
    GameObject music;
    [SerializeField] private PlayerInput playerInput;

    public AudioSource submitAudio;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        music = GameObject.FindGameObjectWithTag("Music");
        Destroy(music);
    }

    void Update() {
        if (playerInput.actions["Jump"].triggered) {
            StartCoroutine(LoadGameScene());
        }
    }

    public IEnumerator LoadGameScene()
    {
        submitAudio.Play();
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Game");
    }

}
