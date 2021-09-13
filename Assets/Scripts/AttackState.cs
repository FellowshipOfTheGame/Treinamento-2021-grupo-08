using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackState : State
{
    public IdleState idleState;
    public Animator animator;
    public Transform attackPoint;
    public float attackRange;
    public LayerMask enemyLayers;
    public float attackRate = 0.5f;
    float nextAttackTime = 0f;
    public bool possoAtacar;
    // Start is called before the first frame update
    
    protected void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            nextAttackTime = Time.time + 1f/attackRate;
            possoAtacar = true;
        }
    }

    // Update is called once per frame
    public override State RunCurrentState()
    {
            Debug.Log("ataquei" + Time.time + " " + nextAttackTime);
        if (possoAtacar)
        {
            Attack();
            possoAtacar = false;
        }
        //nao deixar bater quando o jogador morrer
        return idleState;
    }

    protected abstract void Attack();

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        return;
        Gizmos.DrawWireSphere(attackPoint.position,attackRange);
    }
}
