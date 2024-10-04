using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class CharacterSelectionManager : MonoBehaviour
{
    public AudioSource characterSelect;
    public AudioSource submitAudio;
    public CharacterSelector[] characters;
    private int currentIndex = 0;
    [SerializeField] private PlayerInput playerInput;
    Vector2 move;

    private float moveCooldown = 0.2f;
    private float nextMoveTime = 0f;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        SelectCharacter();
    }

    private void Update()
    {
        Vector2 input = playerInput.actions["Move"].ReadValue<Vector2>();
        move = input;

        Debug.Log("move.x: " + move.x);


        if (Time.time >= nextMoveTime)
        {
            if (move.x > 0)
            {
                MoveSelection(1);
                nextMoveTime = Time.time + moveCooldown;
            }
            else if (move.x < 0)
            {
                MoveSelection(-1);
                nextMoveTime = Time.time + moveCooldown;
            }
        }

        if (playerInput.actions["Jump"].triggered) {
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