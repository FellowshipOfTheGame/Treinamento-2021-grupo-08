using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    public IdleState idleState;
    public Animator animator;
    public Transform attackPoint;
    public float attackRange;
    public LayerMask enemyLayers;
    public float attackRate = 0.5f;
    float nextAttackTime = 0f;

    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            nextAttackTime = Time.time + 1f/attackRate;
        }
    }

    public override State RunCurrentState()
    {
        if (Time.time >= nextAttackTime)
        {
            Attack();
            nextAttackTime = Time.time + 1f/attackRate;
        }
        //nao deixar bater quando o jogador morrer
        return idleState;
    }

    void Attack()
    {
        //animator.SetTrigger("Attack");
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange,enemyLayers);
        foreach (Collider enemy in hitEnemies)
        {
            Debug.Log("atacado " + enemy.name);
			enemy.gameObject.GetComponent<Character>().Hit(10);
		}
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        return;
        Gizmos.DrawWireSphere(attackPoint.position,attackRange);
    }
}

