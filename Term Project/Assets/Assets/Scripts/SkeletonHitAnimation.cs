using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SkeletonHitAnimation : MonoBehaviour
{
    public Animator animator;
    public CharacterStats stats;
    public Collider weaponCollider;
    public NavMeshAgent agent;

    void OnEnable()
    {
        stats.OnHit += PlayHurtAnimation;
        stats.OnDeath += PlayDeathAnimation;
    }

    void OnDisable()
    {
        stats.OnHit -= PlayHurtAnimation;
        stats.OnDeath -= PlayDeathAnimation;
    }

    void PlayHurtAnimation()
    {
        animator.SetTrigger("Damage");
    }

    void PlayDeathAnimation()
    {
        if (agent != null)
        {
            agent.enabled = false;
        }
        weaponCollider.enabled = false;
        animator.SetBool("Dead", true);
        Destroy(gameObject, 1f); // Adjust the delay as needed
    }
}
