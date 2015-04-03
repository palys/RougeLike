using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : HealthController {

	public Slider slider;
	
	void Start () {
		slider.minValue = 0;
		slider.maxValue = maxHealth;
		slider.value = health;
	}

	public override void OnHealthChanged () {
		slider.value = health;
	}

	public override void OnDeath () {

	}
}
