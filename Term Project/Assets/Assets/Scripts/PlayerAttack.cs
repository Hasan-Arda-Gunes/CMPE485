using System;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Collider swordCollider;
    public int damage = 10;
    public int attackNumber = 0;
    public int maxAttackNumber = 3;
    public Animator animator;
    private float lastClickTime;
    public float comboResetTime = 0.5f;
    private bool attacking = false;

    void Start()
    {
        if (swordCollider != null) swordCollider.enabled = false;
    }

    public void Attack()
    {
        lastClickTime = Time.time;

        attackNumber++;
        if (attackNumber > maxAttackNumber) attackNumber = 1;

        TriggerAnimation();
    }

    public void SpinAttack()
    {
        lastClickTime = Time.time;
        attackNumber = 4; // Specialized ID for Spin
        TriggerAnimation();
    }

    private void TriggerAnimation()
    {
        if (animator != null)
        {
            animator.SetInteger("AttackIndex", attackNumber);
            animator.SetTrigger("DoAttack");
        }
        swordCollider.enabled = true;
        attacking = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) Attack();
        if (Input.GetKeyDown(KeyCode.LeftShift)) SpinAttack();

        if (attackNumber != 0 && Time.time - lastClickTime > comboResetTime)
        {
            ResetToIdle();
        }
    }

    void ResetToIdle()
    {
        attackNumber = 0;
        if (animator != null)
        {
            animator.SetInteger("AttackIndex", 0);
        }
        if (swordCollider != null) swordCollider.enabled = false;
        attacking = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        CharacterStats enemyStats = other.GetComponentInParent<CharacterStats>();

        if (enemyStats != null && other.transform.root.CompareTag("Enemy") && swordCollider.enabled && attacking)
        {
            Debug.Log("Confirmed Hit on Root Enemy!");
            enemyStats.TakeDamage(damage);
            attacking = false;
        }
        
    }
}