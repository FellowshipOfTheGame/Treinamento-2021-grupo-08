using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
	[SerializeField] private int maxHealth = 100;
	
	public HealthBar healthBar;
	public Slider slider;
	public Image image;
	public Text name;

	public HealthSystem healthSystem;

	// Start is called before the first frame update
    void Start()
    {
    	healthSystem = new HealthSystem(maxHealth);
		healthBar.Setup(healthSystem, slider, image, name);
	}

	public void Hit(int damage) {
		healthSystem.Damage(damage);
	}
	
	private void FixedUpdate() {
		// Checks if player is dead
		if(healthSystem.GetHealth() == 0) {
//			Movement movement = GetComponent<Movement>();
//			movement.enabled = false;
//			Debug.Log("Player is dead!!!");
			// Death Animation
			// animator.SetTrigger("Death");
		}
	}
}
