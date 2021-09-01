using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
	
	public int maxHealth = 100;
	
	private bool isDead = false;
	
	public HealthBar healthBar;
	public Slider slider;
	public Image image;
	public Text name;
	// Start is called before the first frame update
    void Start()
    {
    	HealthSystem healthSystem = new HealthSystem(maxHealth);
		healthBar.Setup(healthSystem, slider, image, name);
	}

    // Update is called once per frame
    void Update()
    {
		
    }

	private void FixedUpdate()
	{
		if(!isDead)
		{
			
		} else
		{
		}
	}

}
