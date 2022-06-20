using System.Threading.Tasks;
using UnityEngine;

public class MothSpawning : MonoBehaviour {
	[SerializeField] int spawnInterval;
	private void Start() {
		var task = Task.Run(async () => {
			for(;;) {
				await Task.Delay(spawnInterval);
				// spawn shiz
			}
		});
	}
}