using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingState : State
{
    public AttackState attackState;
    public bool isInAttackRange;
    public Transform transformPlayer;

    public Transform transformEnemy;
    public CharacterController controller;
    public float speed = 2f;

    public override State RunCurrentState()
    {
        //verificar se o player esta na range de ataque
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
        
        Vector3 direction = (positionPlayer - positionEnemy).normalized;

        if (direction.x > 0.1f)
        {
            transform.localScale = new Vector3(-1,1,1);
        }
        if (direction.x < 0.1f)
        {
            transform.localScale = new Vector3(1,1,1);
        }

        if(direction.magnitude >= 0.1f)
        {
            controller.Move(direction*speed*Time.deltaTime);
        }
    }
}
