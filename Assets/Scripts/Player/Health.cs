using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] Controller controller;

    [SerializeField] float startingHealth;
    public float currentHealth { get; private set; }

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
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);
    }
}
