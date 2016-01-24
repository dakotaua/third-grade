﻿using UnityEngine;
using System.Collections;

/**
 * Player movement follows the mouse. Find the mouse's position in game space,
 * orient to it (although this game's player has no orientation) and move towards
 * it. 
 */
public class PlayerMovement : MonoBehaviour {

	[SerializeField]
	private float speed;
	private Rigidbody2D playerRigidBody;

	void Start() {
		playerRigidBody = GetComponent<Rigidbody2D> ();
	}

	void Update() {
		var v3 = Input.mousePosition;
		lookAtMouse (v3);
		moveTowardsMouse (v3);
	}


	void fixedUpdate() {

	}

	private void lookAtMouse(Vector3 v3FromMouse) {
		v3FromMouse.z = 20.0f;
		var mousePosition = Camera.main.ScreenToWorldPoint (v3FromMouse);
		Quaternion desiredRotation = Quaternion.LookRotation (transform.position - mousePosition, Vector3.forward);
		desiredRotation.x = 0.0f;
		desiredRotation.y = 0.0f;
		transform.rotation = desiredRotation;
	}

	private void moveTowardsMouse(Vector3 v3FromMouse) {

		v3FromMouse.z = 20.0f;
		playerRigidBody.AddForce (transform.up * speed);
	}

}