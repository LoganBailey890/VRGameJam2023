using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkBehaviour : StateMachineBehaviour
{
    [SerializeField] float minPatrolTime;
    [SerializeField] float maxPatrolTime;
    private float patrolTime;
    List<Transform> PatrolPoints = new();
    NavMeshAgent agent;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        patrolTime = Random.Range(minPatrolTime,maxPatrolTime);
        agent = animator.GetComponent<NavMeshAgent>();
        GameObject way = GameObject.FindGameObjectWithTag("PatrolPoints");
        foreach (Transform t in way.transform)
            PatrolPoints.Add(t);
        agent.SetDestination(PatrolPoints[Random.Range(0, PatrolPoints.Count)].position);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        if (agent.remainingDistance <= agent.stoppingDistance)
            agent.SetDestination(PatrolPoints[Random.Range(0, PatrolPoints.Count)].position);

       
        patrolTime -= Time.deltaTime;
        if (patrolTime <= 0)
        {
            animator.SetBool("Patrol", false);

        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}