using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LeaveManager : MonoBehaviour
{
	[SerializeField] CameraController controller;
	[SerializeField] Transform otherLeafManager;
	public UnityEvent<string, float, float> changedLocation;
	

    // Start is called before the first frame update
    void Start()
    {
        changedLocation = new UnityEvent<string, float, float>();
		controller.cameraChange.AddListener((float oldLocation, float newLocation) => {
			float distanceOtherToNew = Math.Abs(newLocation - otherLeafManager.position.x);
			float distanceToNew = Math.Abs(newLocation - transform.position.x);
			// if this collection of leaves is no longer seen
			if(distanceToNew > distanceOtherToNew) {
				// calculate the difference between the new of camera and old * 2, 1-0 = 1 -> *2 = 2, -1-0 * 2 = -2
				float difference = (newLocation - oldLocation) * 2;
				changedLocation.Invoke(gameObject.tag, transform.position.x, transform.position.x + difference);
				transform.position += new Vector3(difference, 0, 0);
			} else {
				float difference = (newLocation - oldLocation) * 2;
				changedLocation.Invoke(otherLeafManager.tag, otherLeafManager.position.x, otherLeafManager.position.x + difference);
				otherLeafManager.position += new Vector3(difference, 0, 0);

			}
		});
    }
}
