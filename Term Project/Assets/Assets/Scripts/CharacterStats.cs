using System;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    // The Observer Event
    public event Action OnHit;
    public event Action<float> OnHealthChanged;
    public event Action OnDeath;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        // Notify all observers
        OnHealthChanged?.Invoke((float)currentHealth / maxHealth);
        OnHit?.Invoke();

        if (currentHealth <= 0)
        {
            OnDeath?.Invoke();
        }
    }
}