using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressStart : MonoBehaviour
{

    [SerializeField] public Image pressStart;
    public AudioSource submitAudio;

    public void Start() {
        pressStart.gameObject.LeanScale(new Vector3(1.2f, 1.2f), 0.9f).setLoopPingPong();
    }

    public void Update() {
        if(Input.GetButtonDown("Jump")) {
            StartCoroutine(StartSelectorScene());
        }
    }

    public IEnumerator StartSelectorScene()
    {
        submitAudio.Play();
        pressStart.gameObject.LeanScale(new Vector3(1.2f, 1.2f), 0.1f).setLoopPingPong();
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Selector");
    }
}
