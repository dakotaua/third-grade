using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseMenuScript : MonoBehaviour {

	[SerializeField]
	private GameObject pauseUI;
	private bool isPaused;

	// Use this for initialization
	void Start () {
		pauseUI.SetActive (false);
		isPaused = false;
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown (KeyCode.Space))
			isPaused = !isPaused;

		pauseUI.SetActive (isPaused);

		if (isPaused) {
			Time.timeScale = 0;
		}

		if (!isPaused) {

			Time.timeScale = 1;
		}
	}
}
