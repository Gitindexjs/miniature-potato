using UnityEngine;

public class PlayerHealth : MonoBehaviour {
	public int health = 10;
	[SerializeField] GameObject[] hearts;
	private void Update() {

		for(int i = 0; i < health; i++) {
			hearts[i].SetActive(true);
		}
		for(int i = health; i < 10; i++) {
			hearts[i].SetActive(false);
		}
	}
}