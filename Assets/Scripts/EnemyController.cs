using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyController : MonoBehaviour
{
    public Transform[] patrolPoints;
    public int currentPatrolPoint;
    public NavMeshAgent agent;
    public Animator animator;
    public float waitAtPointTime = 2f;
    private float waitCounter;
    public enum AIState { Idle, Patrol, Chase, Attack };
    public AIState currentState;
    public float chaseRange;
    public float attackRange = 1f;
    public float attackDelay = 2f;
    private float attackCounter;
    void Start()
    {
        waitCounter = waitAtPointTime;
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, PlayerController.instance.transform.position);

        switch (currentState)
        {
            case AIState.Idle:
                animator.SetBool("isMoving", false);
                if (waitCounter > 0)
                {
                    waitCounter -= Time.deltaTime;
                }
                else
                {
                    currentState = AIState.Patrol;
                    agent.SetDestination(patrolPoints[currentPatrolPoint].position);
                }

                if (distanceToPlayer <= chaseRange)
                {
                    currentState = AIState.Chase;
                    animator.SetBool("isMoving", true);
                }
                break;

            case AIState.Patrol:
                // agent.SetDestination(patrolPoints[currentPatrolPoint].position);

                if (agent.remainingDistance <= .2f)
                {
                    currentPatrolPoint++;
                    if (currentPatrolPoint >= patrolPoints.Length)
                    {
                        currentPatrolPoint = 0;
                    }

                    // agent.SetDestination(patrolPoints[currentPatrolPoint].position);
                    currentState = AIState.Idle;
                    waitCounter = waitAtPointTime;
                }
                if (distanceToPlayer <= chaseRange)
                {
                    currentState = AIState.Chase;
                }

                animator.SetBool("isMoving", true);
                break;

            case AIState.Chase:
                agent.SetDestination(PlayerController.instance.transform.position);

                if(distanceToPlayer <= attackRange)
                {
                    currentState = AIState.Attack;
                    animator.SetTrigger("Attack");
                    animator.SetBool("isMoving", false);
                    agent.velocity = Vector3.zero;
                    agent.isStopped = true;
                }

                if(distanceToPlayer > chaseRange)
                {
                    currentState = AIState.Idle;
                    waitCounter = waitAtPointTime;
                    agent.velocity = Vector3.zero;
                    agent.SetDestination(transform.position);
                }

                break;
            case AIState.Attack:

                transform.LookAt(PlayerController.instance.transform, Vector3.up);
                transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);
                attackCounter -= Time.deltaTime;
                if(attackCounter <= 0)
                {
                    if(distanceToPlayer <= attackRange)
                    {
                        animator.SetTrigger("Attack");
                        attackCounter = attackDelay;
                    }
                    else
                    {
                        currentState = AIState.Idle;
                        waitCounter = waitAtPointTime;
                        agent.isStopped = false;

                        
                    }
                }
                
                break;
        }
    }
}
