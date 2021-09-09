using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingState : State
{
    public AttackState attackState;
    public bool isInAttackRange;

    public override State RunCurrentState()
    {
        if (isInAttackRange)
        {
            return attackState;
        }
        return this;
    }
}
