using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour {

	public float timeBetweenAttacks = 1.0f;

	public GameObject fireGameObject;

	private float prevAttackTime = 0.0f;

	void Start () {
	
	}

	void FixedUpdate () {
	
		if (Time.time - prevAttackTime >= timeBetweenAttacks) {
			float horizontalAxis = Input.GetAxis(Constants.HORIZONTAL_FIRE);
			float verticalAxis = Input.GetAxis(Constants.VERTICAL_FIRE);

			if ((Mathf.Abs(horizontalAxis) > 0.0f || Mathf.Abs(verticalAxis) > 0.0f)) {
				prevAttackTime = Time.time;
				attack (horizontalAxis, verticalAxis);
			}
		}
	}

	private void attack(float hor, float vert) {
		float dx = Mathf.Sign (hor) * (Mathf.Abs (hor) > 0.01f ? 1.0f : 0.0f);
		float dy = Mathf.Sign (vert) * (Mathf.Abs (vert) > 0.01f ? 1.0f : 0.0f);
		Vector3 direction = new Vector3 (dx, dy, 0);
		Vector3 fireOrigin = transform.position;
		GameObject fireBall = Instantiate (fireGameObject, fireOrigin, Quaternion.identity) as GameObject;
		FireBallController controller = fireBall.GetComponent<FireBallController> ();
		controller.target = fireOrigin + direction * 100;
	}
}
