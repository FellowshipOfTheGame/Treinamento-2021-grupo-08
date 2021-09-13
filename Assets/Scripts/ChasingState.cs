using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingState : State
{
    public AttackState attackState;
    public bool isInAttackRange;
    public Transform transformPlayer;
    public float attackDistance;
	
	public Animator animator;

    public Transform transformEnemy;
    public CharacterController controller;
  	public float speed = 2f;

    public override State RunCurrentState()
    {
        Vector3 positionEnemy = transformEnemy.position;
        Vector3 positionPlayer = transformPlayer.position;
        Vector3 direction = new Vector3(positionPlayer.x - positionEnemy.x, 0f, positionPlayer.z - positionEnemy.z);
//		Vector3 direction = (positionPlayer - positionEnemy);
        float distance = (direction.x*direction.x) + (direction.z*direction.z);
        if (attackDistance*attackDistance > distance)
        {
            isInAttackRange = true;
        }
        else
        {
            isInAttackRange = false;
        }
        if (isInAttackRange)
        {
            return attackState;
        }
        Chase();
        return this;
    }

    void Chase()
    {
        Vector3 positionEnemy = transformEnemy.position;
        Vector3 positionPlayer = transformPlayer.position;
        //Vector3 direction = (positionPlayer - positionEnemy).normalized;
		Vector3 direction = new Vector3(positionPlayer.x - positionEnemy.x, 0f, positionPlayer.z - positionEnemy.z).normalized;
        if (direction.x > 0.1f)
        {
            transformEnemy.localScale = new Vector3(-1,1,1);
        }
        if (direction.x < 0.1f)
        {
            transformEnemy.localScale = new Vector3(1,1,1);
        }

        if(direction.magnitude >= 0.1f)
        {
            controller.Move(direction*speed*Time.deltaTime);
			animator.SetBool("Walking", true); 
	    } 
		//else 
	//	{
	//		animator.SetBool("Walking", false);
	//	}
    }
}
