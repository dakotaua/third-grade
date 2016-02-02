using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	[SerializeField]
	private int score;
	[SerializeField]
	private Text scoreLabel;
	[SerializeField]
	private Text levelLabel;
	[SerializeField]
	private GameObject protoCoin;
	[SerializeField]
	private GameObject protoBall;
	[SerializeField]
	private GameObject protoNode;
	[SerializeField]
	private GameObject protoPlayer;
	private int curLevel;
	private int coinCount;

	// Use this for initialization
	void Start () {
		resetGame ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void resetGame() {
		curLevel = 1;
		coinCount = 0;
		updateLabels ();
		initLevel (1);
	}

	public void scorePoints(int points) {

		score += points;
		updateLabels ();
	}

	public void updateLabels() {

		scoreLabel.text = ("Score: " + score);
		levelLabel.text = ("Level: " + curLevel);
	}

	public void initLevel(int levelNum) {

		curLevel = levelNum;
		resetPlayerPosition ();
		updateLabels ();
		createAndPlaceCoins (2*levelNum + 1);
		createAndPlaceBalls ((levelNum-1) / 2);
		createAndPlaceNodes ((levelNum+1) / 2);

	}

	public void collectCoin(GameObject coin) {
		
		Destroy(coin);
		scorePoints(1);
		coinCount--;
		if (coinCount == 0)
			progressLevel ();
	}

	/**
	 * 	 level dimensions
	 *   -19 to 19 in x
	 * 	 -10 to 10 in y
	 */
	private void createAndPlaceCoins(int numCoins) {

		for (int i = 0; i < numCoins; i++) {
			GameObject coin = (GameObject) Instantiate (protoCoin, getRandomVectorOnLevel(), new Quaternion());
			coin.transform.parent = transform;
		}
		coinCount = numCoins;
	}

	private void createAndPlaceBalls(int numBalls) {

		for (int i = 0; i < numBalls; i++) {
			GameObject ball = (GameObject) Instantiate (protoBall, getRandomVectorOnLevel(), new Quaternion());
			ball.transform.parent = transform;
		}

	}

	private void createAndPlaceNodes(int numNodes) {

		for (int i = 0; i < numNodes; i++) {
			GameObject node = (GameObject) Instantiate (protoNode, getRandomVectorOnLevel(), new Quaternion());
			node.transform.parent = transform;
		}
	}

	private Vector3 getRandomVectorOnLevel() {
		float x = getRandomFloatBetween (-19, 19);
		float y = getRandomFloatBetween (-10, 10);
		return new Vector3 (x, y);
	}

	private float getRandomFloatBetween(int min, int max) {
		return (Random.value * (max - min)) + min;
	}

	private void progressLevel() {

		clearGameObjects ();
		curLevel++;
		initLevel(curLevel);
	}

	private void clearGameObjects() {

		foreach (Transform child in transform) {
			if (child.CompareTag ("deadly") || child.CompareTag("Player")) {
				Destroy (child.gameObject);
			}
		}
	}

	private void resetPlayerPosition() {

		GameObject player = (GameObject) Instantiate (protoPlayer);
		player.transform.parent = transform;
	}


}
