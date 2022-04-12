using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public WalkState walkstate;
    public AttackState attackstate;
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
            GetComponentInParent<Animator>().SetBool("Death", false);
            GetComponentInParent<Animator>().SetBool("Velocity", true);
            return walkstate;
        }
        else if (ifIsInAttackRange)
        {
            ifIsInAttackRange = false;
            attackstate.ifIsInAttackRange = true;
            GetComponentInParent<Animator>().SetBool("Velocity", false);
            GetComponentInParent<Animator>().SetBool("Attack", true);
            return attackstate;
        }
        else if (IfDied)
        {
            IfDied = false;
            GetComponentInParent<Animator>().SetBool("Velocity", false);
            GetComponentInParent<Animator>().SetBool("Attack", false);
            GetComponentInParent<Animator>().SetBool("Die", true);
            return deathstate;
        }
        else
        {
            return this;
        }


    }


}