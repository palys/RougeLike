using UnityEngine;
using System.Collections;

public class Track : MonoBehaviour {

	public GameObject target;

	public float speed = 0.1f;

	public Camera cam;

	void Start () {

		if (cam == null) {
			cam = Camera.main;
		}
	}
	
	void FixedUpdate() {

		Vector3 targetPos = target.transform.position;
		Vector3 sourcePos = transform.position;

		Vector3 delta = targetPos - sourcePos;
		Vector3 deltaClamped = Vector3.ClampMagnitude (delta, speed);

		transform.position += deltaClamped;

	}
}
