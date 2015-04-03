using UnityEngine;
using System.Collections;

public class EnemyHealth : HealthController {
	
	void Start () {

	}

	void Update () {
	
	}
	
	public override void OnHealthChanged() {
		float newNotRed = ((float)health / maxHealth);
		GetComponent<SpriteRenderer> ().color = new Color (1, newNotRed, newNotRed, 1);
	}

	public override void OnDeath() {
		Destroy (gameObject);
	}
}
