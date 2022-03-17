using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{

    public WalkState walkstate;
    public IdleState idlestate;
    public DeathState deathstate;
    public bool ifIsInAttackRange;
    public bool ifIsInWalkMode;
    public bool IfDied;
    public override State RunCurrentState()
    {


        if (ifIsInWalkMode)
        {
            ifIsInWalkMode = false;
            walkstate.ifIsInWalkMode = true;
            GetComponentInParent<Animator>().SetBool("Attack", false);
            GetComponentInParent<Animator>().SetBool("Velocity", true);
            return walkstate;
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