using System.ComponentModel;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using UnityEngine;

public class MothSpawning : MonoBehaviour {
	[SerializeField] int spawnInterval;
	[SerializeField] GameObject mothPrefab;
	[SerializeField] CameraController controller;
	[SerializeField] bool horizontal;
	long counter = 0;
	private void Start() {
		// var task = Task.Run(async () => {
		// 	for(;;) {
		// 		GameObject clone = Instantiate(mothPrefab, transform.position, Quaternion.identity);
		// 		clone.transform.position += new Vector3(1, 5, 0);
		// 		Debug.Log("spawned " + clone.transform.position);
		// 		await Task.Delay(spawnInterval);
		// 	}
		// });
		if(horizontal) {
		controller.cameraChange.AddListener((float oldLoc, float newLoc) => {
			transform.position = new Vector3(newLoc, transform.position.y, transform.position.z);
		});
		}
	}
	private void Update() {
		if(!horizontal) {
		transform.position = new Vector3(0, controller.transform.position.y + 5, 0);
		}
	}
	private void FixedUpdate() {
		if(counter % spawnInterval == 0) {
			if(horizontal) {
				GameObject clone = Instantiate(mothPrefab, transform.position, Quaternion.identity);
				clone.transform.position += new Vector3(0, 5, 0);

			} else {
				Instantiate(mothPrefab, transform.position, Quaternion.identity);
			}
		}
		counter++;
	}
}