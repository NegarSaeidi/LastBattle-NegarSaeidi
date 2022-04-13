using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy2Behaviour : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform[] patrolPoints;
    private Transform nextDestination;
    private int currentPatrolPointIndex;
    public bool walkActivated, inAttackMode;
    public GameObject player;
    public int turnSpeed;

    void Start()
    {
        //agent = GetComponent<NavMeshAgent>();
        //currentPatrolPointIndex = 0;
        //nextDestination = patrolPoints[currentPatrolPointIndex];
        //agent.SetDestination(nextDestination.position);
        //StartCoroutine(CauseDelay(2.0f));

    }



    void Update()
    {
        if (Vector3.Magnitude((player.transform.position - transform.position)) < 3 && (!MovementController.ShieldInUse))
        {
            transform.Find("States").transform.Find("Idle").GetComponent<IdleState>().ifIsInAttackRange = true;
            Vector3 targetDelta = player.transform.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(targetDelta);

            transform.rotation = rotation;
        }
        else
        {
            transform.Find("States").transform.Find("Attack").GetComponent<AttackState>().ifIsInAttackRange = false;
        }
        //    inAttackMode = true;
        //    if (walkActivated)
        //    {


        //        transform.Find("States").transform.Find("Walk").GetComponent<WalkState>().ifIsInAttackRange = true;

        //    }
        //    else
        //    {
        //        transform.Find("States").transform.Find("Idle").GetComponent<IdleState>().ifIsInAttackRange = true;

        //    }

     



        //}

        //else if (inAttackMode)
        //{
        //    inAttackMode = false;
        //    walkActivated = false;
        //    transform.Find("States").transform.Find("Idle").GetComponent<IdleState>().ifIsInAttackRange = false;
        //    transform.Find("States").transform.Find("Walk").GetComponent<WalkState>().ifIsInAttackRange = false;
        //    transform.Find("States").transform.Find("Attack").GetComponent<AttackState>().ifIsInAttackRange = false;

        //    StartCoroutine(CauseDelay(2.0f));
        //}
        //if (walkActivated)
        //{
        //    MoveToNextPoint();
        //    if (currentPatrolPointIndex < 0)
        //    {
        //        walkActivated = false;
        //        transform.Find("States").transform.Find("Walk").GetComponent<WalkState>().ifIsInWalkMode = false;
        //        int rand = Random.Range(10, 25);
        //        currentPatrolPointIndex = 0;
        //        nextDestination = patrolPoints[currentPatrolPointIndex];

        //        StartCoroutine(CauseDelay(rand));
        //    }
        //}



    }

    IEnumerator CauseDelay(float wait)
    {
        yield return new WaitForSeconds(wait);
        agent.SetDestination(nextDestination.position);
        walkActivated = true;
        transform.Find("States").transform.Find("Idle").GetComponent<IdleState>().ifIsInWalkMode = true;

    }
    private void MoveToNextPoint()
    {

        if (agent.remainingDistance <= 0.1f)
        {

            if (currentPatrolPointIndex < patrolPoints.Length - 1)
            {
                currentPatrolPointIndex++;
            }
            else
            {
                currentPatrolPointIndex = -1;
            }
            if (currentPatrolPointIndex > 0)
            {
                nextDestination = patrolPoints[currentPatrolPointIndex];
                agent.SetDestination(nextDestination.position);
            }

        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, 3);
    }
}