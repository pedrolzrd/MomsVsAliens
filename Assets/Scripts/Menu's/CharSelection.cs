using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharSelection : MonoBehaviour
{
    public GameObject[] characters;
    public int selectedChar = 0;
    public GameObject[] charNames;
    public GameObject PlayButton;


    public void NextChar()
    {
        characters[selectedChar].SetActive(false);
        charNames[selectedChar].SetActive(false);
        selectedChar = (selectedChar + 1) % characters.Length;
        characters[selectedChar].SetActive(true);
        charNames[selectedChar].SetActive(true);

        PlayButton.SetActive(selectedChar == 0);
        

    }

    public void PreviousChar()
    {
        characters[selectedChar].SetActive(false);
        charNames[selectedChar].SetActive(false);
        selectedChar--;
        if(selectedChar < 0)
        {
            selectedChar += characters.Length;
        }
        characters[selectedChar].SetActive(true);
        charNames[selectedChar].SetActive(true);
        PlayButton.SetActive(selectedChar == 0);
    }

    public void StartGame()
    {
        PlayerPrefs.SetInt("selectedChar", selectedChar);
        SceneManager.LoadScene("Intro"); 
    }

}
