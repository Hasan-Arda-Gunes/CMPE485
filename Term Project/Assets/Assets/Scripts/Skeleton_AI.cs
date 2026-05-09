using UnityEngine;
using UnityEngine.AI;

public class SkeletonAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Animator animator;
    public Transform player;

    private float lastAttackTime;
    public float attackCooldown = 1.5f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player != null && agent.isActiveAndEnabled && agent.isOnNavMesh)
        {
            float targetSpeed = DifficultyManager.Instance.currentGlobalSpeed;
            agent.speed = targetSpeed;

            float speedMultiplier = targetSpeed / DifficultyManager.Instance.initialSpeed;
            animator.speed = speedMultiplier;

            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            if (distanceToPlayer <= agent.stoppingDistance)
            {
                FaceTarget();
                agent.isStopped = true;

                if (Time.time - lastAttackTime > attackCooldown)
                {
                    animator.SetTrigger("Attack");
                    lastAttackTime = Time.time;
                }
            }
            else
            {
                agent.isStopped = false;
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

}