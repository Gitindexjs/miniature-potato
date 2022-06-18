using UnityEngine;
using UnityEngine.Events;

public class OnEndAttack : MonoBehaviour {
	public void attackEnd() {
		gameObject.SetActive(false);
	}
}