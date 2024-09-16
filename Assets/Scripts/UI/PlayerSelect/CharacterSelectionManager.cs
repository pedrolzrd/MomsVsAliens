using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CharacterSelectionManager : MonoBehaviour
{
    public AudioSource characterSelect;
    public AudioSource submitAudio;
    public CharacterSelector[] characters;
    private int currentIndex = 0;

    private void Start()
    {
        SelectCharacter();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveSelection(-1);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveSelection(1);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            characters[currentIndex].SelectCharacter();
            StartCoroutine(StartGameAfterDelay());
        }
    }

    private void MoveSelection(int direction)
    {
        characters[currentIndex].HoverOutCharacter();

        currentIndex += direction;
        if (currentIndex < 0)
        {
            currentIndex = characters.Length - 1;
        }
        else if (currentIndex >= characters.Length)
        {
            currentIndex = 0;
        }

        SelectCharacter();
        characterSelect.Play();
    }

    private void SelectCharacter() {
        characters[currentIndex].HoverInCharacter();
    }

    public IEnumerator StartGameAfterDelay()
    {
        submitAudio.Play();
        yield return new WaitForSeconds(0.5f);
        PlayerPrefs.SetInt("selectedChar", currentIndex);

        SceneManager.LoadScene("Intro");
    }
}