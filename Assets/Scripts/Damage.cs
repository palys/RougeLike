using UnityEngine;
using System.Collections;

public class Damage : MonoBehaviour {

	private float previousAttackTime = 0;

	private GameObject player;

	public float timeBetweenAttacs = 1;

	public float attackStrengthMin = 2;

	public float attackStrengthMax = 5;

	void Start() {

		player = GameObject.FindGameObjectWithTag ("Player");

	}

	void FixedUpdate() {

	}

	void OnCollisionStay2D(Collision2D col) {

		if (col.gameObject.tag == "Player") {
			DoDamage();
		}
	}

	private void DoDamage() {
		if (Time.time - previousAttackTime >= timeBetweenAttacs) {
			previousAttackTime = Time.time;
			player.GetComponent<PlayerHealth>().Damage((int)Random.Range (attackStrengthMin, attackStrengthMax));
		}
	}
}
