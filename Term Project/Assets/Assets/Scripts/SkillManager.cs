using UnityEngine;
using TMPro;

public class SkillManager : MonoBehaviour
{
    public int points = 0;
    public TextMeshProUGUI pointsText;

    [Header("Player References")]
    public PlayerAttack playerAttack;
    public CharacterStats playerStats;
    public PlayerMovement playerMovement;

    [Header("Skill Settings")]
    public int attackUpgradeCost = 10;
    public int spinUnlockCost = 50;
    public int speedUpgradeCost = 20;
    private bool isSpinUnlocked = false;

    [Header("Health Refill Settings")]
    public int healthRefillCost = 25;
    public TextMeshProUGUI healthCostDisplay;

    [Header("Cost UI Texts")]
    public TextMeshProUGUI attackCostDisplay;
    public TextMeshProUGUI speedCostDisplay;
    public TextMeshProUGUI spinCostDisplay;

    void Start()
    {
        UpdateUI();
        if (playerAttack != null) playerAttack.canSpin = false;
    }

    public void AddPoints(int amount)
    {
        points += amount;
        UpdateUI();
    }

    public void UpgradeAttack()
    {
        if (points >= attackUpgradeCost)
        {
            points -= attackUpgradeCost;
            playerAttack.damage += 5;
            attackUpgradeCost = Mathf.RoundToInt(attackUpgradeCost * 1.5f);
            UpdateUI();
        }
    }

    public void UpgradeSpeed()
    {
        if (points >= speedUpgradeCost)
        {
            points -= speedUpgradeCost;
            playerMovement.speed += 1f; // Increase movement speed
            speedUpgradeCost = Mathf.RoundToInt(speedUpgradeCost * 2);
            UpdateUI();
        }
    }

    public void UnlockSpin()
    {
        if (!isSpinUnlocked && points >= spinUnlockCost)
        {
            points -= spinUnlockCost;
            isSpinUnlocked = true;
            playerAttack.canSpin = true;
            UpdateUI();
        }
    }

    public void RefillHealth()
    {
        if (points >= healthRefillCost && playerStats.currentHealth < playerStats.maxHealth)
        {
            points -= healthRefillCost;

            playerStats.currentHealth = playerStats.maxHealth;
            playerStats.TakeDamage(0);

            healthRefillCost = Mathf.RoundToInt(healthRefillCost * 2);
            UpdateUI();
        }
    }

    void UpdateUI()
    {
        // Update Total Points
        if (pointsText != null) pointsText.text = "Points: " + points;

        // Update Attack Cost
        if (attackCostDisplay != null)
            attackCostDisplay.text = "Cost: " + attackUpgradeCost;

        // Update Speed Cost
        if (speedCostDisplay != null)
            speedCostDisplay.text = "Cost: " + speedUpgradeCost;

        // Update Spin Cost or status
        if (spinCostDisplay != null)
        {
            spinCostDisplay.text = isSpinUnlocked ? "UNLOCKED" : "Cost: " + spinUnlockCost;
        }

        if (healthCostDisplay != null)
        {
            healthCostDisplay.text = "Cost: " + healthRefillCost;
        }
    }
}