using System;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public Collider swordCollider;
    // The Observer Event
    public event Action OnHit;
    public event Action<float> OnHealthChanged;
    public event Action OnDeath;
    public Boolean isDead = false;

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
        if (currentHealth > 0){
            OnHit?.Invoke();
        }

        if (currentHealth <= 0 && !isDead)
        {
            // if this is a skeleton add points to the player score
            if (gameObject.CompareTag("Enemy"))
            {
                FindObjectOfType<SkillManager>().AddPoints(10);
            }
            swordCollider.enabled = false;
            OnDeath?.Invoke();
            isDead = true;
        }
    }
}