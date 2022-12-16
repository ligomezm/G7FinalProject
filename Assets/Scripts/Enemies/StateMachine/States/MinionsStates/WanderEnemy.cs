using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WanderEnemy : StateMachineBehaviour
{
    NavMeshAgent navAgent;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex) 
    {
        if (navAgent == null)
            navAgent = animator.GetComponent<NavMeshAgent>();
    }
    
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex) 
    {
        if (ChaseEnemy.ShouldChasePlayer(animator.transform.position))
            animator.SetInteger(IdleEnemy.transitionParameter, (int) Transition.CHASE);
        else if (!navAgent.hasPath)
        {
            animator.SetInteger(IdleEnemy.transitionParameter, (int) Transition.IDLE);
        }
    }
}
