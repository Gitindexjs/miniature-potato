using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudAttach : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other) {
		if(other.gameObject.tag == "Player") {
			other.transform.parent = transform;
		}
	}
	private void OnCollisionExit2D(Collision2D other) {
		if(other.gameObject.tag == "Player") {
			other.transform.parent = null;
		}	
	}
}
