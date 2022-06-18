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
	// [SerializeField] RectTransform interactionPrompt;
	// [SerializeField] CameraController cameraController;
	[SerializeField] TMP_Text papersCollectedDisplay;
	UnityEvent<string> onInteractCollide;
	UnityEvent<string> onInteractUncollide;
	[System.NonSerialized] public List<string> closeInteractables;
	[System.NonSerialized] public int papers = 0;
	private void Start() {
		onInteractCollide = new UnityEvent<string>();
		onInteractUncollide = new UnityEvent<string>();
		closeInteractables = new List<string>();
		onInteractCollide.AddListener(interactionApproach);
		onInteractUncollide.AddListener(interactionExit);
		// cameraController.cameraChange.AddListener(cameraChange);
		
	}
	private void Update() {
		Collider2D[] colliders = Physics2D.OverlapCircleAll(interactionCheck.position, interaction_radius, interactables);
		List<string> newColliders = new List<string>();
		List<string> returnedColliders = closeInteractables.ToList();
		for (int i = 0; i < colliders.Length; i++)
		{
			// if new collision is not collected in list
			if(closeInteractables.Find(x => colliders[i].gameObject.name == x) == null) {
				onInteractCollide.Invoke(colliders[i].gameObject.name);

			}
			// if it is in the collisions then remove it from hitlist - if still colliding dont remove
			if(closeInteractables.Find(x => colliders[i].gameObject.name == x) != null) {
				returnedColliders.Remove(colliders[i].gameObject.name);
			}
			
		}
		foreach(string leftInteraction in returnedColliders) {
			onInteractUncollide.Invoke(leftInteraction);
		}
		if(Input.GetButtonDown("Interact")) {
			if(closeInteractables.Count != 0) {
				GameObject.Find(closeInteractables[0]).SetActive(false);
				papers++;
				papersCollectedDisplay.text = "Papers " + papers + "/5";
				if(papers == 5) {
					Debug.Log("Collected all papers");

					// cool shiz
				}
			}
		}

		
	}
	void interactionApproach(string name) {
		// if(closeInteractables.Count == 0) {
			
		// 	interactionPrompt.anchoredPosition = GameObject.Find(name).GetComponent<Transform>().position * 40f;
		// 	interactionPrompt.gameObject.SetActive(true);

		// }
		closeInteractables.Add(name);
	}
	void interactionExit(string name) {
		closeInteractables.Remove(name);
		// if(closeInteractables.Count == 0) {
		// 	interactionPrompt.gameObject.SetActive(false);
		// } else {
		// 	Debug.Log(closeInteractables[0]);
		// 	interactionPrompt.anchoredPosition = GameObject.Find(closeInteractables[0]).GetComponent<Transform>().position;
		// }
	}
	// void cameraChange() {
	// 	if(closeInteractables.Count != 0) {
	// 		interactionPrompt.anchoredPosition = GameObject.Find(closeInteractables[0]).GetComponent<Transform>().position;
	// 	}
	// }
}