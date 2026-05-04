using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    public Slider healthSlider;
    public CharacterStats targetStats;

    void OnEnable()
    {
        targetStats.OnHealthChanged += UpdateHealthBar;
    }

    void OnDisable()
    {
        targetStats.OnHealthChanged -= UpdateHealthBar;
    }

    void UpdateHealthBar(float healthPercent)
    {
        healthSlider.value = healthPercent;
    }
}