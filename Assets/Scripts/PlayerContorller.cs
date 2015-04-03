using UnityEngine;
using System.Collections;

public class PlayerContorller : MonoBehaviour {

	public Camera cam;

	public float verticalSpeed = 1.0f;

	public float horizontalSpeed = 1.0f;

	public float attackDistance = 2.0f;

	public float timeBetweenAttacks = 1.0f;

	private float maxWidth;

	private float maxHeight;

	private float vertMargin;

	private float horizontalMargin;

	void Start () {
	
		if (cam == null) {
			cam = Camera.main;
		}

		Vector3 upperCorner = new Vector3 (Screen.width, Screen.height, 0);
		Vector3 targetPosition = cam.ScreenToWorldPoint (upperCorner);

		maxWidth = targetPosition.x;
		maxHeight = targetPosition.y;

		Vector2 extents = GetComponent<Renderer>().bounds.extents;

		vertMargin = extents.y;
		horizontalMargin = extents.x;

		maxWidth -= horizontalMargin;
		maxHeight -= vertMargin;
	}

	void FixedUpdate () {

		movePlayer ();

	}

	Vector3 clampPlayerPosition(Vector3 newPosition)
	{
		Vector3 clamped = new Vector3 (Mathf.Clamp (newPosition.x, -maxWidth, maxWidth), Mathf.Clamp (newPosition.y, -maxHeight, maxHeight), newPosition.z);
		return clamped;
	}

	void movePlayer() {

		Vector3 probablyNewPosition = transform.position + deltaPosition ();
		Vector3 newPosition = clampPlayerPosition (probablyNewPosition);
		transform.position = newPosition;
	}

	Vector3 deltaPosition() {

		float dx = Input.GetAxis (Constants.HORIZONTAL_AXIS);
		float dy = Input.GetAxis (Constants.VERTICAL_AXIS);

		return new Vector3 (horizontalSpeed * dx, verticalSpeed * dy, 0);
	}
}
