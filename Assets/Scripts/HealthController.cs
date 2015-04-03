using UnityEngine;
using System.Collections;

public abstract class HealthController : MonoBehaviour {

	public int maxHealth = 100;

	public int health = 100;

	public float timeBetweenHealthLosses = 1.0f;

	private float prevHealthDown = 0.0f;

	void Start () {
		health = maxHealth;
	}

	void Update () {
	
	}

	public void Damage(int amount) {

		if (Time.time - prevHealthDown > timeBetweenHealthLosses) {
			prevHealthDown = Time.time;

			health = Mathf.Max (health - amount, 0);
			OnHealthChanged ();
			
			if (health == 0) {
				OnDeath();
			}
		}

	}

	public abstract void OnHealthChanged ();

	public abstract void OnDeath();
}
