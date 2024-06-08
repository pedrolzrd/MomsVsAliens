using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    public SpriteRenderer[] sprites;
    public int flickerAmnt;
    public float flickerDuration;

    [SerializeField] Controller controller;

    [SerializeField] float startingHealth;
    [SerializeField] public float currentHealth { get; private set; }

    bool canTakeDamage = true;

    public AudioSource audioHurt;

    private void Awake()
    {
        currentHealth = startingHealth;
    }

    private void Update()
    {
        if(currentHealth <= 0)
        {
            controller.GameOver();
        }
    }

    public void TakeDamage(float damage)
    {
        if(canTakeDamage)
        {
            currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);
            audioHurt.Play();
            StartCoroutine(DamageFlicker());
        }
        
    }

    IEnumerator DamageFlicker()
    {
        canTakeDamage = false;
        for(int i = 0; i < flickerAmnt; i++)
        {
            foreach(SpriteRenderer s in sprites)
            {
                s.color = new Color(1f, 1f, 1f, .5f);
            }
            yield return new WaitForSeconds(flickerDuration);
            foreach (SpriteRenderer s in sprites)
            {
                s.color = Color.white;
            }
            yield return new WaitForSeconds(flickerDuration);
            canTakeDamage = true;

        }
    }

}
