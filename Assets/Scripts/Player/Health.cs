using System.Collections;
using TMPro;
using UnityEditorInternal;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    // Player
    [SerializeField] Controller controller;

    // StatusBar
    private GameObject[] healthBars;
    public TextMeshProUGUI lifeCounter;
    private List<BarState> healthBarStates;
    private List<Image> healthBarImages;
    [SerializeField]  private GameObject lifeIcon;
    private Image lifeIconImage;


    // Life
    [SerializeField] float startingLife = 3;
    [SerializeField] public float currentLife { get; private set; }
    [SerializeField] public float maxLife = 3;


    // Health
    [SerializeField] float startingHealth = 9;
    [SerializeField] public float currentHealth { get; private set; }
    [SerializeField] public float maxHealth = 9;


    // Damage
    bool canTakeDamage = true;

    public AudioSource audioHurt;
    public AudioSource audioHeal;
    public AudioSource lifeLostSound;

    // Respawn
    Respawn respawn;


    // Blink
    private bool isBlinking = false;
    private float blinkDuration = 0.15f;


    private void Awake()
    {
        currentLife = startingLife;
        currentHealth = startingHealth;

        lifeIconImage = lifeIcon.GetComponent<Image>();

        healthBarStates = new List<BarState>();
        healthBarImages = new List<Image>();
        healthBars = GameObject.FindGameObjectsWithTag("HealthBar");
        for (int i = 0; i < (int)maxHealth; i++)
        {
            healthBarStates.Add(healthBars[i].GetComponent<BarState>());
            healthBarImages.Add(healthBars[i].GetComponent<Image>());
        }

        respawn = GetComponent<Respawn>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            TakeDamage(3);
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            RecoverHealthAndLife();
        }
    }

    public void TakeDamage(float damage)
    {
        if (canTakeDamage)
        {
            currentHealth -= damage;

            if(currentHealth <= 0) {
                currentLife--;

                if (currentLife == 0)
                {
                    controller.GameOver();
                    return;
                }

                UpdateLifeCounter();
                lifeLostSound.Play();
                currentHealth = maxHealth;
            }

            UpdateHealthBar();
            audioHurt.Play();
        }
    }

    public void UpdateLifeCounter() {
        lifeCounter.text = currentLife.ToString();
    }

    public void UpdateHealthBar() {
        for (int i = 0; i < (int)maxHealth; i++)
        {
            BarState healthBarState = healthBarStates[i];

            if (healthBarState != null)
            {
                if(i < currentHealth) {
                    healthBarState.Active();
                }else {
                    healthBarState.Inactive();
                }
            }
        }

        if (currentHealth <= 3 && !isBlinking)
        {
            StartCoroutine(BlinkHealthBars());
        }
    }

    public IEnumerator BlinkHealthBars()
    {
        isBlinking = true;

        while (currentHealth <= 3)
        {

            Color tempIconColor = lifeIconImage.color;
            tempIconColor.a = 0.66f;
            lifeIconImage.color = tempIconColor;

            for (int i = 0; i < 3; i++)
            {
                if (i < healthBarImages.Count)
                {
                    Color tempColor = healthBarImages[i].color;
                    tempColor.a = 0.66f;
                    healthBarImages[i].color = tempColor;
                }
            }

            yield return new WaitForSeconds(blinkDuration);

            tempIconColor.a = 1f;
            lifeIconImage.color = tempIconColor;
            for (int i = 0; i < 3; i++)
            {
                if (i < healthBarImages.Count)
                {
                    Color tempColor = healthBarImages[i].color;
                    tempColor.a = 1f;
                    healthBarImages[i].color = tempColor;
                }
            }

            yield return new WaitForSeconds(blinkDuration);
        }

        isBlinking = false;
    }

    public void RecoverHealthAndLife()
    {
        currentHealth = maxHealth;

        if(currentLife < maxLife) {
            currentLife += 1;
        }

        UpdateHealthBar();
        UpdateLifeCounter();
        audioHeal.Play();
    }

}
