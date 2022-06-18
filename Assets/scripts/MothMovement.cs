using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MothMovement : MonoBehaviour
{
	System.Random rand;
    // Start is called before the first frame update
    void Start()
    {
		rand = new System.Random();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(rand.Next(100)/1000 - 50, rand.Next(100)/1000 - 50, 0);
    }
}
