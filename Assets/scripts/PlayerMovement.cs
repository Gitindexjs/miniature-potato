using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	Vector2 movementVector;
	Rigidbody2D rb;
	Vector2 m_velocity = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movementVector.Set(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

	void FixedUpdate() {
		rb.velocity = Vector2.SmoothDamp(rb.velocity, movementVector * 2.0f, ref m_velocity, 0.05f);
	}
}
