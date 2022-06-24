using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    [SerializeField] Transform player;
	Vector3 startingPoint;
	[SerializeField] PlayerHealth healthManager;
	// Start is called before the first frame update
    void Start()
    {
		startingPoint = player.transform.position;
    }
	private void OnCollisionEnter2D(Collision2D	 other) {
		Debug.Log("collided");
		if(other.gameObject.tag == "Player") {
			healthManager.capacity -= 2;
			healthManager.health = healthManager.capacity;
			player.position = startingPoint;
		};
	}
    // Update is called once per frame
    void Update()
    {

    }
}
