using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MothMovement : MonoBehaviour
{
	[SerializeField] NavMeshAgent agent;

	Vector3 nextLocation;
	bool nextLocationCreated;

    // Update is called once per frame
    void Update()
    {
        if(!nextLocationCreated) findNextLocation();
		if(nextLocationCreated) 
			agent.SetDestination(nextLocation);

		Vector3 distanceToNextLocation = transform.position - nextLocation;

		if(distanceToNextLocation.magnitude < 0.2f) {
			nextLocationCreated = false;
		}
    }

	void findNextLocation() {
		float randomX = Random.Range(-2f, 2f);
		float randomY = Random.Range(-2f, 2f);

		nextLocation = new Vector3(transform.position.x + randomX, transform.position.y + randomY, transform.position.z);

		nextLocationCreated = true;

	}
}
