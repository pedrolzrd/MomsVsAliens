using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetKey(KeyCode.Alpha0))
        {
            SceneManager.LoadScene("Menu");
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void RestartAndPlay()
    {
        SceneManager.LoadScene("Game");
    }
    
    public void GoToMenu()

    {
        SceneManager.LoadScene("Menu");
    }
}
