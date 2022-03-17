using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyPatrol : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform[] patrolPoints;
    private Transform nextDestination;
    private int currentPatrolPointIndex;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        currentPatrolPointIndex = 0;
        nextDestination = patrolPoints[currentPatrolPointIndex];
        agent.SetDestination(nextDestination.position);

    }

   
    void Update()
    {
          

        GetComponent<Animator>().SetFloat("Velocity", Vector3.Magnitude(agent.velocity));
        MoveToNextPoint();
           
        

    }
  
    private void MoveToNextPoint()
    {

        if (agent.remainingDistance <= 0.1f)
        {

            if (currentPatrolPointIndex < patrolPoints.Length-1)
            {
                currentPatrolPointIndex++;
            }
            else
            {
                currentPatrolPointIndex = 0;
            }
          
            nextDestination = patrolPoints[currentPatrolPointIndex];
            agent.SetDestination(nextDestination.position);

        }
    }
}
