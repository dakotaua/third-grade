using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public int score;
	public Text scoreLabel;

	// Use this for initialization
	void Start () {
		updateLabels ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void scorePoints(int points) {

		score += points;
		updateLabels ();
	}

	public void updateLabels() {

		scoreLabel.text = ("Score: " + score);
	}
}
