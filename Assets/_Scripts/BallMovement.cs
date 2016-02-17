using UnityEngine;
using System.Collections;

public class BallMovement : MonoBehaviour {

	[SerializeField]
	private float speed;
	[SerializeField]
	private Vector2 initialDirection;
	private Rigidbody2D ballRigidBody;

	// Use this for initialization
	void Start () {	
		ballRigidBody = GetComponent<Rigidbody2D> ();
		ballRigidBody.AddForce (initialDirection* Time.deltaTime * speed);
	}
	
	// Update is called once per frame
	void Update () {

	}


	void OnCollisionEnter2D(Collision2D other) {

		if (other.gameObject.CompareTag ("wall")) {
			adjustBallRotationSlightly ();
		}
	}
		
	/**
	 *   When ball strikes a wall, it should adjust its trajectory slightly to remain unpredictable
	 */
	private void adjustBallRotationSlightly() {
		ballRigidBody.AddRelativeForce (new Vector2 (0.005f, 0.005f));
	}
}
