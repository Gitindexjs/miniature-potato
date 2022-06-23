using UnityEngine;

public class GroundController : MonoBehaviour {
	[SerializeField] Transform player;
	private void Update() {
		transform.position = new Vector3(Mathf.Round(player.position.x/ 19.2f)*19.2f , transform.position.y, transform.position.z);
	}
}