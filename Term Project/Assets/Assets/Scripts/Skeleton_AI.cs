using UnityEngine;
using UnityEngine.AI;

public class SkeletonAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Animator animator;
    public Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player != null && agent.isActiveAndEnabled && agent.isOnNavMesh)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            if (distanceToPlayer <= agent.stoppingDistance)
            {
                // 1. Face the player while attacking
                FaceTarget();

                // 2. Trigger Attack Animation
                animator.SetTrigger("Attack");
            }
            else
            {
                // 3. Move toward player
                agent.SetDestination(player.position);
            }

            animator.SetFloat("Speed", agent.velocity.magnitude);
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    public void OnDeath()
    {
       
    }
}