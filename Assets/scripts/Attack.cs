using UnityEngine;

public class Attack : MonoBehaviour {
	[SerializeField] Animator animator;
	[SerializeField] GameObject net;
	[SerializeField] OnEndAttack endAttackDispatcher;
	[SerializeField] PlayerMovement playerMovementManager;
	[SerializeField] Transform netTrans;
	[SerializeField] Animator netAnimator;
	bool attacking = false;
	private void Start() {
		netAnimator = net.GetComponent<Animator>();
		endAttackDispatcher.attackEnded.AddListener(() => {
			attacking = false;
		});
	}
	private void Update() {
		
		if(Input.GetButtonDown("Attack")) {
			net.SetActive(true);
			netAnimator.Play("netAttack", 0);
			attacking = true;
		}
		if(attacking) {
			Collider2D[] colliders = Physics2D.OverlapCircleAll(netTrans.position, 4f);
			for(int i = 0; i < colliders.Length; i++) {
				if(colliders[i].tag == "Enemy") {
					colliders[i].gameObject.SetActive(false);
				};
			}
		}
	}
}