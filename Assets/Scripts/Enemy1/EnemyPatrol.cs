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
    public bool InAttackMode;
    public GameObject player;
    private Ray sight;
    private RaycastHit rayHit;
    public float speed = 0.01f;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        currentPatrolPointIndex = 0;
        nextDestination = patrolPoints[currentPatrolPointIndex];
        agent.SetDestination(nextDestination.position);

    }

   
    void Update()
    {
        if((Vector3.Magnitude(transform.position - player.transform.position))>3)

        {
            GetComponent<Animator>().SetBool("Attack", false);
            agent.isStopped = false;
            InAttackMode = false;
            GetComponent<Animator>().SetFloat("Velocity", Vector3.Magnitude(agent.velocity));
            MoveToNextPoint();
           
        }
        else
        {
          
            Attack();
        }
           
        

    }
  private void Attack()
    {
        GetComponent<Animator>().SetBool("Attack", true);
        agent.isStopped = true;
        InAttackMode = true;
        transform.LookAt(player.transform.position, transform.up);
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
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
