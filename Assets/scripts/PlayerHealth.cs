using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[System.Serializable]
struct Offset {
	public float x;
	public float y;
}

public class PlayerHealth : MonoBehaviour {
	public int health;
	[SerializeField] Offset heartOffset;
	[SerializeField] float heartSpacing;
	public int capacity;
	[SerializeField] Transform heartParent;
	[SerializeField] GameObject heartDuple;
	private GameObject[] hearts;

	[SerializeField] Image blackImage;
	public UnityEvent death;
	Vector3 originalLocation;
	private void Start() {
		health = capacity;
		hearts = new GameObject[capacity];
		for(int i = 0; i < capacity/2; i++){
			hearts[i] = Instantiate(heartDuple);
			hearts[i].transform.SetParent(heartParent);
			hearts[i].transform.position = new Vector3(heartSpacing * i + heartOffset.x, heartOffset.y, 0);
		}
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

		

		for(int i = 0; -1 < i && i < health; i++) {

			GameObject fullHeart = hearts[Mathf.FloorToInt(i/2)];
			Transform side = fullHeart.transform.GetChild(i % 2);
			side.gameObject.SetActive(true);
		}
		for(int i = health;-1 < i &&  i < 10; i++) {
			GameObject fullHeart = hearts[Mathf.FloorToInt(i/2)];
			Transform side = fullHeart.transform.GetChild(i % 2);
			side.gameObject.SetActive(false);
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