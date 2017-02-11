using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


    private CharacterController controller;

    private Vector3 moveVector, lastMove;

    private float verticalVelocity;

    public float gravity = 14.0f;
    public float jumpForce = 10.0f;
    public float moveSpeed = 0.2f;

	// Use this for initialization
	void Start () {
        controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        moveVector = Vector3.zero;
        moveVector.x = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;

        if (controller.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                verticalVelocity = jumpForce;
            }
        }
        else {
            verticalVelocity -= gravity * Time.deltaTime;
            moveVector = lastMove;
        } 
        moveVector.y = verticalVelocity;
        
        controller.Move(moveVector);

        lastMove = moveVector;
	}


    void OnControllerColliderHit(ControllerColliderHit hit) {
        if (!controller.isGrounded && hit.normal.y < 0.1f) {
            Debug.DrawRay(hit.point, hit.normal, Color.red, 1.25f);
            if (Input.GetKeyDown(KeyCode.Space)) {
                
                verticalVelocity = jumpForce;
                moveVector = hit.normal * moveSpeed;
            }
        }
    }

}
