using UnityEngine;

public class BackgroundManager : MonoBehaviour {
	[SerializeField] CameraController cameraController;
	private void Start() {
		cameraController.cameraChange.AddListener((float oldLocation, float newLocation) => {
			transform.position = new Vector3(newLocation, transform.position.y, transform.position.z);
		});
	}
}