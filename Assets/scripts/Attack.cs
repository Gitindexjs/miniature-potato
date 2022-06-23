using UnityEngine;

public class Attack : MonoBehaviour {
	[SerializeField] GameObject net;
	// [SerializeField] OnEndAttack endAttackDispatcher;
	[SerializeField] PlayerMovement playerMovementManager;
	[SerializeField] Transform netTrans;
	[SerializeField] Animator netAnimator;
	[SerializeField] LayerMask mothLayer;
	public bool attacking = false;
	private void Start() {
		netAnimator = net.GetComponent<Animator>();
		// endAttackDispatcher.attackEnded.AddListener(() => {
		// 	attacking = false;
		// 	Debug.Log("attacking");
		// });
	}
	private void Update() {
		
		if(Input.GetButtonDown("Attack")) {
			net.SetActive(true);
			netAnimator.Play("netAttack", 0);
			attacking = true;
		}
		if(attacking) {
			Collider2D[] colliders = Physics2D.OverlapCircleAll(netTrans.position, 4f, mothLayer);
			for(int i = 0; i < colliders.Length; i++) {
				colliders[i].gameObject.SetActive(false);
			}
		}
	}
}