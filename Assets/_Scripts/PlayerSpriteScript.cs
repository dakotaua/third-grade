﻿using UnityEngine;
using System.Collections;

public class PlayerSpriteScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void LateUpdate() {
		transform.Rotate(new Vector3(0, 0, -0.5f));
	}
}