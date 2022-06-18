using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
	float movementAmp;
	[SerializeField]
	CharacterController2D controller;
	[SerializeField] float walkingSpeed;
	[SerializeField] float runningSpeed;
	[SerializeField] Transform ground;
	bool jumping;
	Animator animator;
	float movementSpeed;
	bool jumpingAnimation;
	[System.NonSerialized] public UnityEvent<string> animationStart;
	[System.NonSerialized] public UnityEvent<string> animationEnd;

    // Start is called before the first frame update
    void Start()
    {
		animator = GetComponent<Animator>();
		animationStart = new UnityEvent<string>();
		animationEnd = new UnityEvent<string>();
		movementSpeed = 10f;
		jumpingAnimation = false;
    }

    // Update is called once per frame
    void Update()
    {
        movementAmp = Input.GetAxisRaw("Horizontal");
		
		if(controller.m_Grounded && !jumpingAnimation) {
			if(Input.GetAxisRaw("Horizontal") != 0) {
				if(Input.GetButton("Run")) {
					animator.Play("Running", 0);
					animationStart.Invoke("Running");
				} else {
					animator.Play("Walking", 0);
					animationStart.Invoke("Walking");
				}
			} else {
				animator.Play("Idle", 0);
				animationStart.Invoke("Idle");
			}
		}
		if(Input.GetButtonDown("Jump")) {
			jumping = true;
			jumpingAnimation = true;
			animator.Play("Jumping", 0);
			animationStart.Invoke("Jumping");
		} 
		if(Input.GetAxisRaw("Horizontal") != 0) {
			if(Input.GetButton("Run")) {
					movementSpeed = runningSpeed;
				} else {
					movementSpeed = walkingSpeed;
				}
		}
		ground.position = new Vector3(Mathf.Round(transform.position.x/ 19.2f)*19.2f , ground.position.y, ground.position.z);
    }

	void FixedUpdate() {
		controller.Move(movementAmp * Time.fixedDeltaTime * movementSpeed, false, jumping);
		jumping = false;
	}
	public void onAnimationEnd(string name) {
		if(name == "Jumping") {
			jumpingAnimation = false;
		}
		animationEnd.Invoke(name);
	}
}
