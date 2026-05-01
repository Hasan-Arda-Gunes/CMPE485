using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public Collider swordCollider;
    public int damage = 10;
    public int attackNumber = 0;
    public int maxAttackNumber = 3;
    public Animator animator;
    private float lastClickTime;
    public float comboResetTime = 1f;

    void Start()
    {
        swordCollider.enabled = false;
    }

    public void Attack()
    {
        swordCollider.enabled = true;
        attackNumber = (attackNumber + 1) % (maxAttackNumber + 1);
        if (animator != null)
        {
            animator.SetInteger("Attack", attackNumber);
        }
        lastClickTime = Time.time;
    }

    public void SpinAttack()
    {
        swordCollider.enabled = true;
        attackNumber = 4;
        if (animator != null)
        {
            animator.SetInteger("Attack", attackNumber);
        }
        lastClickTime = Time.time;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Space key
        {
            Attack();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift)) // Left Shift key
        {
            SpinAttack();
        }

        if (attackNumber != 0 && Time.time - lastClickTime > comboResetTime)
        {
            attackNumber = 0;
            if (animator != null)
            {
                animator.SetInteger("Attack", attackNumber);
            }
            
            swordCollider.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
    
    }
}