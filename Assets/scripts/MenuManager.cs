using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;


public class MenuManager : MonoBehaviour
{
	[SerializeField] Text narration;
	[SerializeField] VideoPlayer videoPlayer;
	[SerializeField] RawImage videoOut;
	[SerializeField] NarrationController narrationController;

	public void onStartClick() {

		StartCoroutine(fade());
		videoPlayer.Play();
		videoPlayer.loopPointReached += loadScene;
	}
	void loadScene(VideoPlayer vp) {
		SceneManager.LoadScene(1);
	}
	IEnumerator fade() {
		Color color = videoOut.color;
		for(float alpha = 0; alpha <= 1.1f; alpha += 0.01f) {
			color.a = alpha;
			videoOut.color = color;
			yield return null;
		}
		Dictionary<int, NarrationController.scriptConfig> textTimes = new Dictionary<int, NarrationController.scriptConfig>();

		narration.gameObject.SetActive(true);

		textTimes.Add(10, new NarrationController.scriptConfig("My village used to thrive on the sacred butterfly spirits", 0.2f));
		textTimes.Add(53, new NarrationController.scriptConfig("But 100 years ago a swam of enemy moths took over", 0.2f));
		textTimes.Add(105, new NarrationController.scriptConfig("Locking the butterfly spirit high up in the sky", 0.4f));
		textTimes.Add(192, new NarrationController.scriptConfig("They were ruthless and caused havoc to my land", 0.36f));
		textTimes.Add(270, new NarrationController.scriptConfig("But now, I found a portal that could lead me back in time so stop this tragedy", 0.2f));

		StartCoroutine(narrationController.startNarration(textTimes));
	}
}
