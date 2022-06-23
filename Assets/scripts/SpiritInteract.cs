using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpiritInteract : MonoBehaviour
{
   	[SerializeField] float interaction_radius;
	[SerializeField] LayerMask interactables;
	[SerializeField]Transform interactionCheck;
	bool spirit;
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
		spirit = true;
		GameObject.Find(name).SetActive(false);
		Debug.Log("ggs");
		Time.timeScale = 0;
	}
	void interactionExit(string name) {
	}
}
