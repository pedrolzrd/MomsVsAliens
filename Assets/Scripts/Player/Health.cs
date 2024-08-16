using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] SpriteRenderer[] sprites;
    [SerializeField] int hpFlickerAmnt;
    [SerializeField] int satFlickerAmnt;
    [SerializeField] float flickerDuration;

    [SerializeField] float dmg;
    [SerializeField] Controller controller;
    [SerializeField] float startingHealth;
    [SerializeField] public float startingHealthSaturation;

    public float healthSaturation { get; private set; }
    [SerializeField] public float currentHealth { get; private set; }
    [SerializeField] public float maxHealth = 5; 

    bool canTakeDamage = true;

    public AudioSource audioHurt;
    public AudioSource audioHeal;

    Respawn respawn;

    private void Awake()
    {
        currentHealth = startingHealth;
        healthSaturation = startingHealthSaturation;
        respawn = GetComponent<Respawn>();
    }

    private void Update()
    {
        if(currentHealth <= 0)
        {
            controller.GameOver();
        }

        if(healthSaturation < 0)
        {
            
            healthSaturation = startingHealthSaturation;
            currentHealth = Mathf.Clamp(currentHealth - dmg, 0, startingHealth);
            audioHurt.Play();
            StartCoroutine(DamageFlicker(flickerDuration, hpFlickerAmnt));
            respawn.RespawnPlayer();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage(1);
        }
    }

    public void TakeDamage(float damage)
    {
        if(canTakeDamage)
        {
            healthSaturation -= damage;
            audioHurt.Play();
            if(healthSaturation >= 1)
            {
                StartCoroutine(DamageFlicker(flickerDuration, satFlickerAmnt));
            }            
        }        
    }

    public void RecoverLife(float heal)
    {
        if(currentHealth < maxHealth)
        {
            currentHealth = currentHealth + heal;
            audioHeal.Play();            
        }        
    }

    IEnumerator DamageFlicker(float flickerDuration, float flickerAmnt)
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
