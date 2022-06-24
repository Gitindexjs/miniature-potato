using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class Interactions : MonoBehaviour {
	[SerializeField] float interaction_radius;
	[SerializeField] LayerMask interactables;
	[SerializeField]Transform interactionCheck;
	[SerializeField] Sprite[] papersSprites;
	[SerializeField] Image[] papersCollectedDisplay;
	[SerializeField] Transform paperManager;
	[SerializeField] GameObject popup;
	[SerializeField] Image popupImage;
	[SerializeField] Sprite[] popupImages;
	[SerializeField] Image popupConfirm;
	[SerializeField] Sprite[] popupConfirms;
	[SerializeField] VideoPlayer videoPlayer;
	[SerializeField] RawImage videoOut;
	[SerializeField] Image videoBlack;
	[SerializeField] NarrationController narrationController;
	[SerializeField] Text narration;
	GameObject[] papers;
	bool popupShowing;
	bool showedPopup;
	bool showingCongrats;
	Animator popupAnimator;
	#region Events
	UnityEvent<string> onInteractCollide;
	#endregion Events
	[System.NonSerialized] public int papersCollected = 0;
	// [System.NonSerialized] public List<string> closeInteractables;
	// [SerializeField] RectTransform interactionPrompt;
	// [SerializeField] CameraController cameraController;
	
	private void Start() {
		onInteractCollide = new UnityEvent<string>();
		// closeInteractables = new List<string>();
		popupShowing = false;
		showedPopup = false;
		showingCongrats = false;
		popupAnimator = popup.GetComponent<Animator>();
		onInteractCollide.AddListener(interactionApproach);
		papers = new GameObject[paperManager.childCount];
		for(int i = 0; i < paperManager.childCount; i++) {
			papers[i] = paperManager.GetChild(i).gameObject;

		}
		// cameraController.cameraChange.AddListener(cameraChange);
		
	}
	private void Update() {
		Collider2D[] colliders = Physics2D.OverlapCircleAll(interactionCheck.position, interaction_radius, interactables);
		for (int i = 0; i < colliders.Length; i++)
		{
			onInteractCollide.Invoke(colliders[i].gameObject.name);
		}

		if(Input.GetMouseButtonDown(0) && popupShowing) {
			popupShowing = false;
			popup.SetActive(false);
			Time.timeScale = 1;
		}
		if(Input.GetMouseButtonDown(0) && showingCongrats) {
			showingCongrats = false;
			popup.SetActive(false);
			Time.timeScale = 1;
			StartCoroutine(fade());
			videoPlayer.Play();
			videoPlayer.loopPointReached += loadScene;
		}
		
	}
	void interactionApproach(string name) {
		if(papersCollected == 0 && !showedPopup) {
			showedPopup = true;
			papersCollectedDisplay[0].gameObject.SetActive(true);
			papersCollectedDisplay[1].gameObject.SetActive(true);
			for(int i =0; i < papers.Length; i++) {
				papers[i].SetActive(true);
			}
			popupImage.sprite = popupImages[0];
			popupConfirm.sprite = popupConfirms[0];
			popup.SetActive(true);
			
			popupAnimator.Play("Popping", 0);
			popupShowing = true;
			Time.timeScale = 0;
		}
		papersCollectedDisplay[1].sprite = papersSprites[papersCollected];
		papersCollected++;
		if(papersCollected == papers.Length + 1) {
			popupImage.sprite = popupImages[1];
			popupConfirm.sprite = popupConfirms[1];
			popup.SetActive(true);
			
			popupAnimator.Play("Popping", 0);
			showingCongrats = true;
			Time.timeScale = 0;
			
		}
		GameObject.Find(name).SetActive(false);
	}
	public void resetPapers() {
		papersCollected = 0;
		for(int i = 0; i < papers.Length; i++) {
			papers[i].SetActive(true);
		}
	}
	IEnumerator fade() {
		Color color = videoOut.color;
		for(float alpha = 0; alpha <= 1.1f; alpha += 0.01f) {
			color.a = alpha;
			videoOut.color = color;
			yield return null;
		}
		Dictionary<int, NarrationController.scriptConfig> textTimes = new Dictionary<int, NarrationController.scriptConfig>();

		videoBlack.gameObject.SetActive(true);	
		
		textTimes.Add(20, new NarrationController.scriptConfig("The papers put together lead me to the coordinates of these ruins", 0.15f));
		textTimes.Add(53, new NarrationController.scriptConfig("Inside there was a crystal potion", 0.2f));
		textTimes.Add(90, new NarrationController.scriptConfig("I wonder what it does…", 0.4f));

		StartCoroutine(narrationController.startNarration(textTimes));
	}
	void loadScene(VideoPlayer vp) {
		SceneManager.LoadScene(2);
	}
	// void cameraChange() {
	// 	if(closeInteractables.Count != 0) {
	// 		interactionPrompt.anchoredPosition = GameObject.Find(closeInteractables[0]).GetComponent<Transform>().position;
	// 	}
	// }
}