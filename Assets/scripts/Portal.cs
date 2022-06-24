using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class Portal : MonoBehaviour {
	[SerializeField] LayerMask player;
	[SerializeField] float portalRadius;
	[SerializeField] SpiritInteract spiritInteract;
	[SerializeField] RawImage videoOut;
	[SerializeField] VideoPlayer videoPlayer;
	[SerializeField] NarrationController narrationController;
	bool successfullyCollided;
	private void Start() {
		successfullyCollided = false;
	}
	private void Update() {
		Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, portalRadius, player);
		if(!successfullyCollided) {
			for (int i = 0; i < colliders.Length; i++)
			{
				if(spiritInteract.spirit) {
					successfullyCollided = true;
					videoOut.gameObject.SetActive(true);
					videoPlayer.Play();
					videoPlayer.loopPointReached += loadScene;
					Dictionary<int, NarrationController.scriptConfig> textTimes = new Dictionary<int, NarrationController.scriptConfig>();

			
					textTimes.Add(10, new NarrationController.scriptConfig("My land was finally restored!", 0.35f));
					textTimes.Add(45, new NarrationController.scriptConfig("The peace loving butterflies have returned", 0.3f));
					textTimes.Add(85, new NarrationController.scriptConfig("I finished my quest. The End", 0.4f));

					StartCoroutine(narrationController.startNarration(textTimes));
				}
			}

		}
	}
	private void loadScene(VideoPlayer vp) {
		SceneManager.LoadScene(0);
	}
}