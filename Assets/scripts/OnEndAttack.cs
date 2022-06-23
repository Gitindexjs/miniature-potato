using UnityEngine;
using UnityEngine.Events;

public class OnEndAttack : MonoBehaviour {
	[SerializeField] Attack attackController;
	public UnityEvent attackEnded;
	private void Start() {
		attackEnded = new UnityEvent();
	}
	public void attackEnd() {
		attackEnded.Invoke();
		attackController.attacking = false;
		gameObject.SetActive(false);
	}
}