using UnityEngine;
using System.Collections;

/**
 * Player movement follows the mouse. Find the mouse's position in game space,
 * orient to it and move towards it.
 */
public class PlayerMovement : MonoBehaviour {

	[SerializeField]
	private float speed;
	private Rigidbody2D playerRigidBody;
	private GameController game;

	void Start() {
		game = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ();
		playerRigidBody = GetComponent<Rigidbody2D> ();
	}

	void Update() {

		var v3 = Input.mousePosition;
		lookAtMouse (v3);
		moveTowardsMouse (v3);
	}

	void OnTriggerEnter2D(Collider2D other) {
		
		if (other.gameObject.CompareTag ("deadly")) {
		}
			

		if (other.gameObject.CompareTag ("coin")) {
			
			game.collectCoin (other.gameObject);
		}
		
	}

	void OnCollisionEnter2D(Collision2D other) {

		if (other.gameObject.CompareTag ("deadly"))
			Debug.Log ("Touched deadly");

	}

	void fixedUpdate() {

	}

  /**
 	* Player movement follows the mouse. Find the mouse's position in game space,
 	* orient to it and move towards it.
 	*/
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
