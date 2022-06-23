using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
	public int health = 10;
	[SerializeField] GameObject[] hearts;
	[SerializeField] Image blackImage;
	public UnityEvent death;
	Vector3 originalLocation;
	private void Start() {
		originalLocation = transform.position;
		death = new UnityEvent();
	}
	private void Update() {

		if(health == 0) {
			death.Invoke();
			// health = 10;
			// interactionController.resetPapers();
			// transform.position = originalLocation;
			StartCoroutine(fade());
		}
		for(int i = 0; i < health; i++) {
			hearts[i].SetActive(true);
		}
		for(int i = health; -1 < i && i < 10; i++) {
			hearts[i].SetActive(false);
		}
	}
	IEnumerator fade() {
		Color color = blackImage.color;
		for(float alpha = 0; alpha <= 1.1f; alpha += 0.001f) {
			color.a = alpha;
			blackImage.color = color;
			yield return null;
		}
		SceneManager.LoadScene(0);
	}
}