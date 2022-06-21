using System.ComponentModel;
using System.Threading.Tasks;
using UnityEngine;

public class MothSpawning : MonoBehaviour {
	[SerializeField] int spawnInterval;
	[SerializeField] GameObject mothPrefab;
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
	}
	private void FixedUpdate() {
		if(counter % 500 == 0) {
			GameObject clone = Instantiate(mothPrefab, transform.position, Quaternion.identity);
			clone.transform.position += new Vector3(1, 5, 0);
		}
		counter++;
	}
}