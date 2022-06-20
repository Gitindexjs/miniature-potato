using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MothMovement : MonoBehaviour
{
	[SerializeField] Transform player;
	Renderer mothRenderer;
	// [SerializeField] NavMeshAgent agent;

	// Vector3 nextLocation;
	// bool nextLocationCreated;

	bool chasing;

	bool previouslySeen;

	void Start() {
		mothRenderer = GetComponent<Renderer>();
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
		if(chasing) {
			Vector3 distance = player.transform.position - transform.position;
			transform.position += distance.normalized * 0.05f;
		}

	}

	// void findNextLocation() {
	// 	float randomX = Random.Range(-2f, 2f);
	// 	float randomY = Random.Range(-2f, 2f);

	// 	nextLocation = new Vector3(transform.position.x + randomX, transform.position.y + randomY, transform.position.z);

	// 	nextLocationCreated = true;

	// }
}
