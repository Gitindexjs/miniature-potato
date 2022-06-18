using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafController : MonoBehaviour
{
	float multiplier;
	Vector3 originalLocation;
	float counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        multiplier = 0.05f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = originalLocation + new Vector3(0,0,0 );
		counter += 0.01f;
    }
}
