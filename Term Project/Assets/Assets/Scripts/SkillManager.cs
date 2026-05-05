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

    [Header("Cost UI Texts")]
    public TextMeshProUGUI attackCostDisplay;
    public TextMeshProUGUI speedCostDisplay;
    public TextMeshProUGUI spinCostDisplay;

    void Start()
    {
        UpdateUI();
        // Start with spin locked if you want
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
            playerAttack.damage += 5; // Increase damage
            attackUpgradeCost = Mathf.RoundToInt(attackUpgradeCost * 1.5f); // Scale cost
            UpdateUI();
        }
    }

    public void UpgradeSpeed()
    {
        if (points >= speedUpgradeCost)
        {
            points -= speedUpgradeCost;
            playerMovement.speed += 1.5f; // Increase movement speed
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
    }
}