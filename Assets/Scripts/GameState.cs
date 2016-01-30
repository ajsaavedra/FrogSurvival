using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameState : MonoBehaviour {

	private bool gameStarted = false;
	public static bool isPaused = false;
	[SerializeField]
	private Text gameStateText;
	[SerializeField]
	private GameObject player;
	[SerializeField]
	private BirdMovement birdMovement;
	[SerializeField]
	private FollowCamera followCamera;
	private float restartDelay = 3f;
	private float restartTimer;
	private PlayerMovement playerMovement;
	private PlayerHealth playerHealth;

	// Use this for initialization
	void Start () {
		Cursor.visible = false;
		playerMovement = player.GetComponent<PlayerMovement> ();
		playerHealth = player.GetComponent<PlayerHealth> ();

		//Prevent player, camera and bird movement at start
		playerMovement.enabled = false;
		birdMovement.enabled = false;
		followCamera.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!gameStarted && Input.GetKeyUp(KeyCode.Space)) {
			StartGame();
		}

		if (gameStarted && Input.GetKeyDown("space")) {
			if (!isPaused) {
				isPaused = true;
				PauseGame();
			} else {
				isPaused = false;
				ResumeGame();
			}
		}

		if (!playerHealth.isAlive && HealthMeter.totalHealth==0) {
			EndGame();
			RestartTimer();
		}

		if (ScoreCounter.score == 20) {
			WinGame();
			RestartTimer();
		}
	}

	private void RestartTimer() {
		restartTimer += Time.deltaTime;
		if (restartTimer >= restartDelay) {
			Application.LoadLevel(Application.loadedLevel);
		}
	}

	private void StartGame() {
		gameStarted = true;
		gameStateText.color = Color.clear;
		playerMovement.enabled = true;
		birdMovement.enabled = true;
		followCamera.enabled = true;

	}

	private void PauseGame() {
		Time.timeScale = 0;
		gameStateText.color = Color.white;
		playerMovement.enabled = false;
		birdMovement.enabled = false;
		followCamera.enabled = false;
		gameStateText.text = "Press space to resume";
	}

	private void ResumeGame() {
		Time.timeScale = 1;
		gameStateText.color = Color.clear;
		playerMovement.enabled = true;
		birdMovement.enabled = true;
		followCamera.enabled = true;
	}

	private void EndGame() {
		gameStarted = false;
		gameStateText.color = Color.white;
		gameStateText.text = "Game Over";

		//Remove player from game
		player.SetActive (false);
	}

	private void WinGame() {
		gameStarted = false;
		gameStateText.color = Color.white;
		if (HealthMeter.totalHealth == 100) {
			gameStateText.text = "Perfect";
		} else {
			gameStateText.text = "Win!";
		}

		//Remove player from game
		player.SetActive (false);
	}
}
