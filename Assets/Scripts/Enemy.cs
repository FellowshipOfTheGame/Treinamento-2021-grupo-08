using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : Character
{

    void Start()
    {
    	healthSystem = new HealthSystem(maxHealth);
		int enemies = FindObjectsOfType<Enemy>().Length;	
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

