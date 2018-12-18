using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairFollow : MonoBehaviour {

	private Vector3 velocity = Vector3.zero;
	public float smoothTime = 0.125f;

	private void LateUpdate()
	{
		Vector3 desiredPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		desiredPosition.z = 0;
		Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothTime);
		transform.position = desiredPosition;
	}
}
