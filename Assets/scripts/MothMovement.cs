using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MothMovement : MonoBehaviour
{
	GameObject player;
	Transform playerTrans;
	[SerializeField] Animator animator;
	PlayerHealth playerHealth;
	Renderer mothRenderer;
	// [SerializeField] NavMeshAgent agent;

	// Vector3 nextLocation;
	// bool nextLocationCreated;

	bool chasing;

	bool previouslySeen;
	float nextAttackTime;

	void Start() {
		player = GameObject.Find("player");
		mothRenderer = GetComponent<Renderer>();
		playerHealth = player.GetComponent<PlayerHealth>();
		chasing = false;
	}

    // Update is called once per frame
    void Update()
    {
		if(!mothRenderer.isVisible && previouslySeen) {
			chasing = false;
		}
		if(mothRenderer.isVisible) {
			chasing = true;
			animator.Play("Chasing", 0);
			previouslySeen = true;
		}
        // if(!nextLocationCreated) findNextLocation();
		// if(nextLocationCreated) 
		// 	agent.SetDestination(nextLocation);

		// Vector3 distanceToNextLocation = transform.position - nextLocation;

		// if(distanceToNextLocation.magnitude < 0.2f) {
		// 	nextLocationCreated = false;
		// }
    }

	void FixedUpdate() {
		Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 2f);
		for(int i = 0; i < colliders.Length; i++) {
			if(colliders[i].gameObject.name == "player") {
				if(Time.time > nextAttackTime) {
					playerHealth.health --;
					nextAttackTime = Time.time + 2;
					Debug.Log(playerHealth.health);
					if(playerHealth.health == 0) {
						Debug.Log("dead");
					}

				}
			};
		}
		if(chasing) {
			Vector3 distance = player.transform.position - transform.position;
			transform.position += distance.normalized * 0.05f;
			changeDirection((int) (distance.x/Mathf.Abs(distance.x)));
		}

	}

	void changeDirection(int direction) {
		Vector3 theScale = transform.localScale;
		theScale.x = direction;
		transform.localScale = theScale;
	}

	// void findNextLocation() {
	// 	float randomX = Random.Range(-2f, 2f);
	// 	float randomY = Random.Range(-2f, 2f);

	// 	nextLocation = new Vector3(transform.position.x + randomX, transform.position.y + randomY, transform.position.z);

	// 	nextLocationCreated = true;

	// }
}
