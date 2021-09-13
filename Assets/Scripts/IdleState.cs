using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public Transform transformPlayer = null;
    public Transform transformEnemy;
    public ChasingState chaseState;
    public bool canSeeThePlayer;
    public float chaseDistance;

	public Animator animator;
	
    public override State RunCurrentState()
    {
 		animator.SetBool("Walking", false);
	       if (transformPlayer == null)
        {
            transformPlayer = GameObject.Find("Player").transform;
        }
        
        Vector3 positionEnemy = transformEnemy.position;
        Vector3 positionPlayer = transformPlayer.position;
        Vector3 direction = (positionPlayer - positionEnemy);
        float distance = (direction.x*direction.x) + (direction.z*direction.z);
        if (chaseDistance*chaseDistance > distance)
        {
            canSeeThePlayer = true;
        }
        else
        {
            canSeeThePlayer = false;
        }
        if (canSeeThePlayer)
        {
            chaseState.transformPlayer = transformPlayer;
            return chaseState;
        }
        return this;
    }
}
