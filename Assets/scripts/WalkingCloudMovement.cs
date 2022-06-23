using UnityEngine;

public class WalkingCloudMovement : MonoBehaviour {
	[SerializeField] float frequency;
	[SerializeField] float amplitude; 
	private void Update() {
		transform.position += new Vector3(Mathf.Cos((float) Time.timeAsDouble) * frequency, 0, 0) * amplitude;
	}
}