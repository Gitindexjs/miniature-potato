using UnityEngine;
using UnityEngine.Events;

public class OnEndAttack : MonoBehaviour {
	public UnityEvent attackEnded;
	private void Start() {
		attackEnded = new UnityEvent();
	}
	public void attackEnd() {
		attackEnded.Invoke();
		gameObject.SetActive(false);
	}
}