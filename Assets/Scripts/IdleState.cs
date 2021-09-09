using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public Transform transformPlayer = null;
    public ChasingState chaseState;
    public bool canSeeThePlayer;

    public override State RunCurrentState()
    {
        if (transformPlayer == null)
        {
            transformPlayer = GameObject.Find("Player").transform;
        }
        //logica para encontrar o jogador
        if (canSeeThePlayer)
        {
            chaseState.transformPlayer = transformPlayer;
            return chaseState;
        }
        return this;
    }
}
