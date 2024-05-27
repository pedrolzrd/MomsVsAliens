using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void RestartAndPlay()
    {
        SceneManager.LoadScene("Selector");
    }
}
