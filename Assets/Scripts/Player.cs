using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Character
{
	public Animator animator;
    public Transform attackPoint;
    public float attackRange = 5f;
    public LayerMask enemyLayers;
    public float attackRate = 0.5f;
    float nextAttackTime = 0f;

	private int basicAttackDamage = 10;

	public GameObject hat;

    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Z)) {
                BasicAttack();
                nextAttackTime = Time.time + 1f/attackRate;
            }
			if (Input.GetKeyDown(KeyCode.X)) {
				GameObject[] throwed = GameObject.FindGameObjectsWithTag("Hat");
				if(throwed.Length == 0){
					GameObject clone;
					clone = Instantiate(hat, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), transform.rotation) as GameObject;
				}
			}
        }
    }

	void BasicAttack() {
        //animator.SetTrigger("BasicAttack");
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange,enemyLayers);
        foreach (Collider enemy in hitEnemies)
        {
            Debug.Log("atacado " + enemy.name);
			enemy.gameObject.GetComponent<Character>().Hit(basicAttackDamage);
		}
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        return;
        Gizmos.DrawWireSphere(attackPoint.position,attackRange);
    }

	private void FixedUpdate() {
		// Checks if player is dead
		if(healthSystem.GetHealth() == 0) {
			Movement movement = GetComponent<Movement>();
			movement.enabled = false;
			Debug.Log("Player is dead!!!");
			// Death Animation
			// animator.SetTrigger("Death");
		}
	}

}
