using System;
using UnityEngine;

public class InteractableMovement : MonoBehaviour {
	float counter = 0;
	float originalY;
	private void Start() {
		originalY = transform.position.y;
	}
	private void Update() {
		transform.position = new Vector3(transform.position.x, originalY + (float) Math.Sin(counter) * 0.25f, transform.position.z);
		counter+=0.005f;
	}
}