using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    public Animator animator;
    public CharacterStats stats;

    void OnEnable()
    {
        stats.OnHit += PlayHurtAnimation;
    }

    void OnDisable()
    {
        stats.OnHit -= PlayHurtAnimation;
    }

    void PlayHurtAnimation()
    {
        animator.SetTrigger("Damage");
    }

}
