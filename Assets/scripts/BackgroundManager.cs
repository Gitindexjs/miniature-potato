using UnityEngine;

public class BackgroundManager : MonoBehaviour {
	[SerializeField] Transform cameraPosition;
	float previousCameraX;
	private void Update() {
		Vector3 pos = cameraPosition.transform.position;
		if(magicBox(previousCameraX) != magicBox(pos.x)) {
			transform.position = new Vector3(magicBox(pos.x), transform.position.y, transform.position.z);
		}
		previousCameraX = pos.x;
	}
	float magicBox (float position) {
		return Mathf.Round(position / 19.2f) * 19.2f;
	}
}