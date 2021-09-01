using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 5f;
    public LayerMask enemyLayers;
    public float attackRate = 0.5f;
    float nextAttackTime = 0f;

    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Attack();
                nextAttackTime = Time.time + 1f/attackRate;
            }
        }
    }
    void Attack()
    {
        //animator.SetTrigger("Attack");
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange,enemyLayers);
        foreach (Collider enemy in hitEnemies)
        {
            Debug.Log("atacado " + enemy.name);
        }
    }
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        return;
        Gizmos.DrawWireSphere(attackPoint.position,attackRange);
    }
}
