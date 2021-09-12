using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
	
	// UI
	private Slider slider;
	private Image image;
	private Text name;

	private HealthSystem healthSystem;

	public void Setup(HealthSystem healthSystem, Slider slider, Image image, Text name) {
		this.healthSystem = healthSystem;
		this.slider = slider;
		this.image = image;
		this.name = name;
	}	

    // Update is called once per frame
    private void Update()
    {
        slider.value = healthSystem.GetHealthPercent();
    }
}
