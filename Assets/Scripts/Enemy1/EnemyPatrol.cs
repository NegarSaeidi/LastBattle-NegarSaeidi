using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyPatrol : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform startPoint, endPoint;
    private Transform nextDestination;
    private bool waitInIdle;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        nextDestination = startPoint;
        waitInIdle = false;
        
    }

   
    void Update()
    {
           agent.SetDestination(nextDestination.position);

            GetComponent<Animator>().SetFloat("Velocity", Vector3.Magnitude(agent.velocity));

            if (agent.remainingDistance <= 0)
            {
              
                if (nextDestination == startPoint)
                {
                    nextDestination = endPoint;

                }
                else
                {

                    nextDestination = startPoint;

                }

            }
        

    }
    private void OnCollisionEnter(Collision collision)
    {
       
    }
    
}
