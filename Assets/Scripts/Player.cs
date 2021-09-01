using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
	
	public int maxHealth = 100;
	
	public HealthBar healthBar;
	public Slider slider;
	public Image image;
	public Text name;

	private HealthSystem healthSystem;

	// Start is called before the first frame update
    void Start() {
		healthSystem = new HealthSystem(maxHealth);
		healthBar.Setup(healthSystem, slider, image, name);
	}

    // Update is called once per frame
    void Update() {
		// Basic Attack
		if(Input.GetKeyDown(KeyCode.Z))
		{
			// Basic attack animation
			
		}		

    }

	private void FixedUpdate() {
		// Checks if player is dead
		if(healthSystem.GetHealth() == 0) {
			Movement movement = GetComponent<Movement>();
			movement.enabled = false;
			Debug.Log("Player is dead!!!");
			// Death Animation
		}
	}

}
