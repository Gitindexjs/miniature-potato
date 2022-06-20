using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour
{
	float originalX;
	float counter;
    // Start is called before the first frame update
    void Start()
    {
        originalX = transform.position.x;
		counter = 0;
    }

    // Update is called once per frame
    void Update(){
        transform.position = new Vector3(originalX+ Mathf.Sin(counter), transform.position.y, transform.position.z);
		counter+=0.001f;
    }
}
