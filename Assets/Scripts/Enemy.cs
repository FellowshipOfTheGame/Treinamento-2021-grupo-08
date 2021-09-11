using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : Character
{

	HealthBar enemyUI;

    void Start()
    {
    	healthSystem = new HealthSystem(maxHealth);
		healthBar.Setup(healthSystem, slider, image, name);	
		int enemies = FindObjectsOfType<Enemy>().Length;
		healthBar.transform.position = new Vector3(healthBar.transform.position.x, healthBar.transform.position.y-42f*(enemies-1), healthBar.transform.position.z);
	
	}

	private void FixedUpdate() {
		// Checks if player is dead
		if(healthSystem.GetHealth() == 0) {
			Debug.Log("Enemy is dead!!!");
			// Death Animation
			// animator.SetTrigger("Death");
			Destroy(this.gameObject);
		}
	}


}

