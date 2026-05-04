using UnityEngine;

public class SkeletonAttack : MonoBehaviour
{
    public Collider weaponCollider;
    public int damage = 10;
    private bool attacking = false;

    // Start is called before the first frame update
    void Start()
    {
        if (weaponCollider != null) weaponCollider.enabled = false;
    }

    public void EnableWeaponCollider()
    {
        if (weaponCollider != null) weaponCollider.enabled = true;
        attacking = true;
    }

    // This function will be called by the Animation Event
    public void DisableWeaponCollider()
    {
        if (weaponCollider != null) weaponCollider.enabled = false;
        attacking = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        // Check if the skeleton hit the Player
        if (other.CompareTag("Player"))
        {
            CharacterStats playerStats = other.GetComponentInParent<CharacterStats>();
            if (playerStats != null && attacking)
            {
                playerStats.TakeDamage(damage);
                // Disable immediately after a hit to prevent double-damage
                weaponCollider.enabled = false;
                attacking = false;
                
            }
            Debug.Log("Skeleton hit: " + other.name);

        }
        
    }
}
