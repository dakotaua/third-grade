using UnityEngine;
using System.Collections;

public class PlayerSpriteScript : MonoBehaviour {

	private Quaternion desiredRotation = Quaternion.identity;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void LateUpdate() {

		transform.rotation = desiredRotation;
	}
}
