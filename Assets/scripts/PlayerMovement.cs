using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	float movementAmp;
	[SerializeField]
	CharacterController2D controller;
	bool jumping;
	Animator animator;
    // Start is called before the first frame update
    void Start()
    {
		animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movementAmp = Input.GetAxisRaw("Horizontal");
		if(Input.GetButtonDown("Jump")) {
			jumping = true;
		}
		if(Input.GetAxisRaw("Horizontal") != 0) {
			animator.Play("Walking", 0);
		} else {
			animator.Play("Idle", 0);
		}
    }

	void FixedUpdate() {
		controller.Move(movementAmp * Time.fixedDeltaTime * 10f, false, jumping);
		jumping = false;
	}
}
