using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseAttackState : AttackState
{
    protected override void Attack()
    {
        //animator.SetTrigger("Attack");
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange,enemyLayers);
        foreach (Collider enemy in hitEnemies)
        {
            Debug.Log("atacado " + enemy.name);
			enemy.gameObject.GetComponent<Character>().Hit(10);
		}
    }
}

