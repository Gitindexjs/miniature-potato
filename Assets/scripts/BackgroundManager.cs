using UnityEngine;

public class BackgroundManager : MonoBehaviour {
	[SerializeField] CameraController controller;
	[SerializeField] Transform cam;
	private void Start() {
		controller.cameraChange.AddListener(cameraChange);
		
	}
	void cameraChange() {
		Debug.Log("chaing");
		transform.position = new Vector3(cam.position.x, transform.position.y, transform.position.z);
	}
}