using UnityEngine;
using System.Collections;

public class RandomWalk : MonoBehaviour {

	public Camera cam;
	
	public float verticalSpeed = 1.0f;
	
	public float horizontalSpeed = 1.0f;
	
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
	
		float x = Random.value;
		float y = Random.value;

		if (Mathf.Abs(transform.position.x) > 3.13) {
			verticalSpeed = -verticalSpeed;
		}

		if (Mathf.Abs (transform.position.y) > 2.11) {
			horizontalSpeed = - horizontalSpeed;
		}

		transform.position = clampPosition (transform.position + new Vector3 (verticalSpeed * x, horizontalSpeed * y, 0));
	}

	Vector3 clampPosition(Vector3 newPosition)
	{
		Vector3 clamped = new Vector3 (Mathf.Clamp (newPosition.x, -maxWidth, maxWidth), Mathf.Clamp (newPosition.y, -maxHeight, maxHeight), newPosition.z);
		return clamped;
	}
}
