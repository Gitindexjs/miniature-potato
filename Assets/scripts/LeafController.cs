using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LeafController : MonoBehaviour
{
	LeaveManager leafManager;
	float[] multipliers;
	float counter = 0;
	Vector3 original;
    // Start is called before the first frame update
    void Start()
    {
        multipliers = new float[2];
		original = new Vector3(transform.position.x, transform.position.y, transform.position.z);
		multipliers[0] = 0.25f;
		multipliers[1] = 2f;
		leafManager = GameObject.Find("Leaves").GetComponent<LeaveManager>();
		leafManager.changedLocation.AddListener((string tag, float oldLocation, float newLocation) => {
			string parentTag = gameObject.transform.parent.gameObject.tag; 
			if(parentTag == tag) {
				original += new Vector3(newLocation - oldLocation, 0, 0);

			};
		});
    }

    // Update is called once per frame
    void Update() {
		Vector3 animatedPosition = new Vector3(original.x - multipliers[0] * Mathf.Cos(counter), original.y + Mathf.Cos(counter *multipliers[1] ) / 20f, original.z);
		transform.position = animatedPosition;  

		counter+=0.001f;
    }
}
