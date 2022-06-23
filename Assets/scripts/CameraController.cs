using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.LowLevel;

public class CameraController : MonoBehaviour
{
	float previousX;
	[SerializeField] Transform player;
	[SerializeField] bool horizontal;
	public UnityEvent<float, float> cameraChange;
	// [System.NonSerialized] public UnityEvent cameraChange;
	// Vector3 previous;
    // Start is called before the first frame update
    void Awake()
    {
		cameraChange = new UnityEvent<float, float>();
		previousX = -transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
		if(horizontal) {
			Vector3 pos = player.transform.position;
			pos.z = transform.position.z;
			pos.y = transform.position.y;
			transform.position = pos;
			if(magicBox(previousX) != magicBox(pos.x)) {
				cameraChange.Invoke(magicBox(previousX), magicBox(pos.x));
			}
			previousX = pos.x;
		} else {
			transform.position = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
		}
    }
	
	float magicBox (float position) {
		return Mathf.Round(position / 19.2f) * 19.2f;
	}
}
