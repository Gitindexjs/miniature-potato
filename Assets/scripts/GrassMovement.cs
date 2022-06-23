using UnityEngine;

public class GrassMovement : MonoBehaviour {
	[SerializeField] Transform background;
	
	private void Update() {
		transform.position = new Vector3(background.position.x + Mathf.Sin((float) Time.timeAsDouble) / 5, 0.35f, 0);
	}
}