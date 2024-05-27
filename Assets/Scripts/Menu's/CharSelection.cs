using UnityEngine;
using UnityEngine.SceneManagement;

public class CharSelection : MonoBehaviour
{
    public GameObject[] characters;
    public int selectedChar = 0;

    public void NextChar()
    {
        characters[selectedChar].SetActive(false);
        selectedChar = (selectedChar + 1) % characters.Length;
        characters[selectedChar].SetActive(true);
    }

    public void PreviousChar()
    {
        characters[selectedChar].SetActive(false);
        selectedChar--;
        if(selectedChar < 0)
        {
            selectedChar += characters.Length;
        }
        characters[selectedChar].SetActive(true);
    }

    public void StartGame()
    {
        PlayerPrefs.SetInt("selectedChar", selectedChar);
        SceneManager.LoadScene("Game");
    }

}
