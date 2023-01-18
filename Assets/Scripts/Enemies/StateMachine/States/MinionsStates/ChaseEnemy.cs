using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseEnemy : StateMachineBehaviour
{
    public float repathTolerance = 2;
    public float repathCount = 10;
    public float runSpeed = 4;
    public static float chaseRadius = 10;

    PlayerSingleton target;
    
    NavMeshAgent navAgent;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex) 
    {
        if (navAgent == null)
            navAgent = animator.GetComponent<NavMeshAgent>();
        if (target == null)
            target = PlayerSingleton.GetInstance();

        navAgent.ResetPath();
        navAgent.speed = runSpeed;
    }

    public override void OnStateMove(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex) 
    {
        Vector3 currPosition = animator.transform.position;
        if (!ShouldChasePlayer(currPosition))
            animator.SetInteger(IdleEnemy.transitionParameter, (int) Transition.IDLE);
        else if (AttackEnemy.ShouldAttackPlayer(currPosition))
        {
            LookTowardsPlayer(animator.transform, target.transform);
            animator.SetInteger(IdleEnemy.transitionParameter, (int) Transition.ATTACK);
        }
        else 
            if (!navAgent.hasPath || (target.transform.position - navAgent.pathEndPosition).sqrMagnitude > repathTolerance * repathTolerance)
                SetDestinationNearTarget(navAgent, target);    
    }

    public void SetDestinationNearTarget(NavMeshAgent _agent, PlayerSingleton _target)
    {
        NavMeshHit hit;
        float radius = 0;
        for (int i = 0; i < repathCount; ++i)
        {
            Vector3 randomPosition = Random.insideUnitSphere * radius;
            randomPosition += _target.transform.position;
            if(NavMesh.SamplePosition(randomPosition, out hit, radius, 1))
            {
                _agent.SetDestination(hit.position);
                break;
            }
            else
                ++radius;
        }
    }
    public static bool ShouldChasePlayer(Vector3 _chaserPosition)
    {
        PlayerSingleton p = PlayerSingleton.GetInstance();
        return (p.transform.position - _chaserPosition).sqrMagnitude < chaseRadius * chaseRadius;
    }
    private void LookTowardsPlayer(Transform enemy, Transform player)
    {
        enemy.LookAt(player.transform, Vector3.up);
    }
}
