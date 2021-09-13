using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
	[SerializeField] protected int maxHealth = 100;
	public Animator animator;

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

	public int GetHealth()
	{
		return healthSystem.GetHealth();
	}

	public virtual void Hit(int damage) 
	{
		animator.SetTrigger("Impact");
		healthSystem.Damage(damage);
	}

	public void Heal(int amount)
	{
		healthSystem.Heal(amount);
	}
	
}
