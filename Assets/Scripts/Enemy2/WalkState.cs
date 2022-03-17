using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : State
{
    public IdleState idlestate;
    public AttackState attackstate;
    public DeathState deathstate;
    public bool ifIsInAttackRange;
    public bool ifIsInWalkMode;
    public bool IfDied;
    public override State RunCurrentState()
    {
        if (!ifIsInWalkMode)
        {

            idlestate.ifIsInWalkMode = false;
            GetComponentInParent<Animator>().SetBool("Die", false);
            GetComponentInParent<Animator>().SetBool("Attack", false);
            GetComponentInParent<Animator>().SetBool("Velocity", false);
            return idlestate;
        }
        else if (ifIsInAttackRange)
        {
            ifIsInAttackRange = false;
            attackstate.ifIsInAttackRange = true;
            GetComponentInParent<Animator>().SetBool("Die", false);
            GetComponentInParent<Animator>().SetBool("Velocity", false);
            GetComponentInParent<Animator>().SetBool("Attack", true);
            return attackstate;
        }
        else if (IfDied)
        {
            IfDied = false;
            GetComponentInParent<Animator>().SetBool("Attack", false);
            GetComponentInParent<Animator>().SetBool("Velocity", false);
            GetComponentInParent<Animator>().SetBool("Die", true);
            return deathstate;
        }
        else
        {
            return this;
        }
    }
}
