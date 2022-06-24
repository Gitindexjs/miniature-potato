using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.Video;

public class SpiritInteract : MonoBehaviour
{
   	[SerializeField] float interaction_radius;
	[SerializeField] LayerMask interactables;
	[SerializeField]Transform interactionCheck;
	[SerializeField] VideoPlayer videoPlayer;
	[SerializeField] RawImage videoOut;
	public bool spirit;
	#region Events
	UnityEvent<string> onInteractCollide;
	UnityEvent<string> onInteractUncollide;
	#endregion Events
	[System.NonSerialized] public int papersCollected = 0;
	
	private void Start() {
		spirit = false;
		onInteractCollide = new UnityEvent<string>();
		onInteractUncollide = new UnityEvent<string>();
		// closeInteractables = new List<string>();
		
		onInteractCollide.AddListener(interactionApproach);
		onInteractUncollide.AddListener(interactionExit);
		// cameraController.cameraChange.AddListener(cameraChange);
		
	}
	private void Update() {
		Collider2D[] colliders = Physics2D.OverlapCircleAll(interactionCheck.position, interaction_radius, interactables);
		List<string> newColliders = new List<string>();
		for (int i = 0; i < colliders.Length; i++)
		{
			onInteractCollide.Invoke(colliders[i].gameObject.name);
			
		}
		
	}
	void interactionApproach(string name) {
		GameObject.Find(name).SetActive(false);
		spirit = true;
		
	}
	void interactionExit(string name) {
	}
}
