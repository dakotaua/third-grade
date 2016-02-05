using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenuScript : MonoBehaviour {

	[SerializeField]
	private Button startGameButton;

	[SerializeField]
	private Button exitGameButton;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void QuitGame() {

		Application.Quit ();
	}

	public void StartGame() {
		Debug.Log ("start game pressed");
		SceneManager.LoadScene ("base_level");
	}
}
