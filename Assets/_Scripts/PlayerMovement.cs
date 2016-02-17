using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
 * Player movement follows the mouse. Find the mouse's position in game space,
 * orient to it and move towards it.
 */
public class PlayerMovement : MonoBehaviour {

	[SerializeField]
	private float speed;
	private Rigidbody2D playerRigidBody;
	[SerializeField]
	private GameController game;
	private bool movingRight = true;
	private bool movingUp = true;
	private float lastXvel = 0f;
	private float lastYvel = 0f;

	void Start() {
		playerRigidBody = GetComponent<Rigidbody2D> ();
	}

	void Update() {
		movePlayer ();
	}

	void OnTriggerEnter2D(Collider2D other) {


		if (other.gameObject.CompareTag ("deadly")) {
			game.endGame ();
			die ();
		}

		if (other.gameObject.CompareTag ("coin")) {

			game.collectCoin (other.gameObject);
		}

	}

	void OnCollisionEnter2D(Collision2D other) {

		if (other.gameObject.CompareTag ("deadly")) {
			game.endGame ();
			die ();
		}

	}

	void fixedUpdate() {
		
	}
		

	private void movePlayer() {

		// determine vel
		Vector3 fromInput = Input.mousePosition;
		fromInput.z = 20f;
		Vector3 mouse = Camera.main.ScreenToWorldPoint (fromInput);
		Vector3 player = new Vector3 (transform.position.x, transform.position.y, 20f);

		float xDiff = mouse.x - player.x;
		float yDiff = mouse.y - player.y;

		if (mouse.x > player.x) {
			movingRight = true;
		} else {
			movingRight = false;
		}

		if (movingRight) {
			if (xDiff > lastXvel)
				lastXvel = xDiff;
		}
		if (!movingRight) {
			if (xDiff < lastXvel)
				lastXvel = xDiff;
		}
	
		if (mouse.y > player.y) {
			movingUp = true;
		} else {
			movingUp = false;
		}

		if (movingUp) {
			if (yDiff > lastYvel)
				lastYvel = yDiff;
		}
		if (!movingUp) {
			if (yDiff < lastYvel)
				lastYvel = yDiff;
		}
			
		Vector3 moveVec = new Vector3 (lastXvel, lastYvel);
		// speed of 4 or 5 works well
		playerRigidBody.AddForce (moveVec * speed);
	}

	private void die() {
		Debug.Log ("Player dying");
		var children = new List<GameObject> ();
		foreach (Transform t in transform)
			children.Add (t.gameObject);
		children.ForEach (child => Destroy (child));
		Destroy (this);
	}
}
