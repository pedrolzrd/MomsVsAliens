using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    //Music musicObject;


    private void Awake()
    {
        //musicObject = GameObject.FindGameObjectWithTag("Music").GetComponent<Music>();
        
    }

    public void GameOver()
    {
        //Destroy(musicObject);
        SceneManager.LoadScene("GameOver");
    }

    public void RestartAndPlay()
    {
        SceneManager.LoadScene("Game");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
