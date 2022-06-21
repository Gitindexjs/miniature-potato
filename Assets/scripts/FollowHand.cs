using UnityEngine;

public class FollowHand : MonoBehaviour {
	[SerializeField] PlayerMovement playerMovementManager;
	[SerializeField] Animator animator;
	private void Start() {
		playerMovementManager.animationStart.AddListener(onAnimation);
		playerMovementManager.animationEnd.AddListener(onAnimationEnd);
	}
	void onAnimation(string animation){
		if(gameObject.activeSelf) {
			animator.Play("net" + animation, 0);
		}
	}
	void onAnimationEnd(string animation) {
		// dunno
	}
}