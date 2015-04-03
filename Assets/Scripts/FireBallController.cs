using UnityEngine;
using System.Collections;

public class FireBallController : MonoBehaviour {

	public Vector3 target;

	public float speed = 1.0f;

	public int minDamage = 25;

	public int maxDamage = 50;

	void Start () {
	
	}

	void FixedUpdate () {
	
		transform.position = Vector3.MoveTowards (transform.position, target, speed * Time.deltaTime);
		if (Vector3.Distance (target, transform.position) < 0.5f) {
			Destroy(gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "Enemy") {
			col.gameObject.GetComponent<EnemyHealth>().Damage((int)Random.Range(minDamage, maxDamage));
			Destroy (gameObject);
		}
	}
}
