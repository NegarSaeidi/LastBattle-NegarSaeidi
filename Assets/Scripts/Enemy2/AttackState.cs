using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AttackState : State
{

    public WalkState walkstate;
    public IdleState idlestate;
    public DeathState deathstate;
    public bool ifIsInAttackRange;
    public bool ifIsInWalkMode;
    public bool IfDied;


    public GameObject projectile;
    public Transform firePoint;
    private Ray sight;
    private RaycastHit rayHit;
    public float speed = 0.01f;

    private bool bulletshoot;
    private GameObject bullet;
    private void Update()
    {
        if (!MovementController.ShieldInUse )
        {
            if (!bulletshoot)
                SpellAttack();
            else
                transform.GetComponentInParent<NavMeshAgent>().isStopped = false;
        }
    }

    private void SpellAttack()
    {
        transform.GetComponentInParent<NavMeshAgent>().isStopped = true;

        sight.origin = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
        sight.direction = transform.forward;

        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(sight, out rayHit))
        {
            Debug.DrawLine(sight.origin, rayHit.point, Color.red);
            if (rayHit.collider.tag == "Player")
            {
                ShootProjectile();
                bulletshoot = true;
                StartCoroutine(causeDelay());

            }


        }
    }
    IEnumerator causeDelay()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(bullet);
        bulletshoot = false;
    }
    private void ShootProjectile()
    {
        bullet = Instantiate(projectile, firePoint.transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().velocity = (rayHit.point - firePoint.position).normalized * speed; ;
    }
    public override State RunCurrentState()
    {


        if (ifIsInWalkMode)
        {
            ifIsInWalkMode = false;
            walkstate.ifIsInWalkMode = true;
            GetComponentInParent<Animator>().SetBool("Attack", false);
            GetComponentInParent<Animator>().SetBool("Velocity", true);
            return idlestate;
        }
        else if (!ifIsInAttackRange)
        {
            idlestate.ifIsInAttackRange = false;
            GetComponentInParent<Animator>().SetBool("Velocity", false);
            GetComponentInParent<Animator>().SetBool("Attack", false);
            return idlestate;
        }
        else if (IfDied)
        {
            GetComponentInParent<Animator>().SetBool("Die", true);
            return deathstate;
        }
        else
        {
            return this;
        }
    }
}