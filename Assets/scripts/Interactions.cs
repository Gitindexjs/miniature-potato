using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

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
	GameObject[] papers;
	bool popupShowing;
	bool showedPopup;
	bool showingCongrats;
	Animator popupAnimator;
	#region Events
	UnityEvent<string> onInteractCollide;
	UnityEvent<string> onInteractUncollide;
	#endregion Events
	[System.NonSerialized] public int papersCollected = 0;
	// [System.NonSerialized] public List<string> closeInteractables;
	// [SerializeField] RectTransform interactionPrompt;
	// [SerializeField] CameraController cameraController;
	
	private void Start() {
		onInteractCollide = new UnityEvent<string>();
		onInteractUncollide = new UnityEvent<string>();
		// closeInteractables = new List<string>();
		popupShowing = false;
		showedPopup = false;
		showingCongrats = false;
		popupAnimator = popup.GetComponent<Animator>();
		onInteractCollide.AddListener(interactionApproach);
		onInteractUncollide.AddListener(interactionExit);
		papers = new GameObject[paperManager.childCount];
		for(int i = 0; i < paperManager.childCount; i++) {
			papers[i] = paperManager.GetChild(i).gameObject;

		}
		// cameraController.cameraChange.AddListener(cameraChange);
		
	}
	private void Update() {
		Collider2D[] colliders = Physics2D.OverlapCircleAll(interactionCheck.position, interaction_radius, interactables);
		List<string> newColliders = new List<string>();
		// List<string> returnedColliders = closeInteractables.ToList();
		for (int i = 0; i < colliders.Length; i++)
		{
			// // if new collision is not collected in list
			// if(closeInteractables.Find(x => colliders[i].gameObject.name == x) == null) {
			// 	onInteractCollide.Invoke(colliders[i].gameObject.name);

			// }
			// // if it is in the collisions then remove it from hitlist - if still colliding dont remove
			// if(closeInteractables.Find(x => colliders[i].gameObject.name == x) != null) {
			// 	returnedColliders.Remove(colliders[i].gameObject.name);
			// }
			onInteractCollide.Invoke(colliders[i].gameObject.name);
			
		}
		// foreach(string leftInteraction in returnedColliders) {
		// 	onInteractUncollide.Invoke(leftInteraction);
		// }
		// if(Input.GetButtonDown("Interact")) {
		// 	if(closeInteractables.Count != 0) {
		// 		if(papers == 0) {
					
		// 		}
		// 		GameObject.Find(closeInteractables[0]).SetActive(false);
		// 		papers++;
		// 		papersCollectedDisplay.text = "Papers " + papers + "/5";
		// 		if(papers == 5) {
		// 			Debug.Log("Collected all papers");

		// 			// cool shiz
		// 		}
		// 	}
		// }

		if(Input.GetMouseButtonDown(0) && popupShowing) {
			popupShowing = false;
			popup.SetActive(false);
			Time.timeScale = 1;
		}
		if(Input.GetMouseButtonDown(0) && showingCongrats) {
			showingCongrats = false;
			popup.SetActive(false);
			Time.timeScale = 1;
			// Crazy logic to switch scene and shit
		}
		
	}
	void interactionApproach(string name) {
		// if(closeInteractables.Count == 0) {
			
		// 	interactionPrompt.anchoredPosition = GameObject.Find(name).GetComponent<Transform>().position * 40f;
		// 	interactionPrompt.gameObject.SetActive(true);

		// }

		// closeInteractables.Add(name);
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
	void interactionExit(string name) {
		// closeInteractables.Remove(name);
		// if(closeInteractables.Count == 0) {
		// 	interactionPrompt.gameObject.SetActive(false);
		// } else {
		// 	Debug.Log(closeInteractables[0]);
		// 	interactionPrompt.anchoredPosition = GameObject.Find(closeInteractables[0]).GetComponent<Transform>().position;
		// }
	}
	public void resetPapers() {
		papersCollected = 0;
		for(int i = 0; i < papers.Length; i++) {
			papers[i].SetActive(true);
		}
	}
	// void cameraChange() {
	// 	if(closeInteractables.Count != 0) {
	// 		interactionPrompt.anchoredPosition = GameObject.Find(closeInteractables[0]).GetComponent<Transform>().position;
	// 	}
	// }
}