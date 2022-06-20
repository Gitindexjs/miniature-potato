using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CameraController : MonoBehaviour
{
	[SerializeField] Transform player;
	// [System.NonSerialized] public UnityEvent cameraChange;
	// Vector3 previous;
    // Start is called before the first frame update
    void Awake()
    {
		// cameraChange = new UnityEvent();
		// previous = new Vector3();
    }

    // Update is called once per frame
    void Update()
    {
		// previous = transform.position;
        // transform.position = new Vector3(Mathf.Round(player.position.x / 19.2f) * 19.2f, Mathf.Round(player.position.y / 10.8f) * 10.8f, transform.position.z);
		// if(transform.position != previous) {
		// 	cameraChange.Invoke();
		// }
		Vector3 pos = player.transform.position;
		pos.z = transform.position.z;
		pos.y = transform.position.y;
		transform.position = pos;
    }
}
