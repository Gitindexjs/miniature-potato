using UnityEngine;

public class Attack : MonoBehaviour {
	[SerializeField] Animator animator;
	[SerializeField] GameObject net;
	[SerializeField] OnEndAttack endAttackDispatcher;
	[SerializeField] PlayerMovement playerMovementManager;
	private void Update() {
		
		if(Input.GetButtonDown("Attack")) {
			net.SetActive(true);
			animator.Play("Attack", 0);
			playerMovementManager.animationStart.Invoke("Attack");
		}
	}
}