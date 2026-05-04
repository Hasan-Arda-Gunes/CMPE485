using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonHitAnimation : MonoBehaviour
{
    public Animator animator;
    public CharacterStats stats;

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
        animator.SetBool("Dead", true);
    }
}
