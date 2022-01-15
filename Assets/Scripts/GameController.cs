using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public float spawnInterval;
	public float waitBeforeSpawnStart;

	public float missileToTankRatio;

	public Text scoreText;
	public Text gameOverText;
	public Text pauseText;
	public Text gameOverSubtext;

	public Texture2D mouseTexture;
	public Vector2 cursorOffset;
	CursorMode cursorMode = CursorMode.Auto;

	public GameObject playerPrefab;

	GameObject playerInstance;

	int score;
	int bestScore;
	bool gameOver;
	bool restartButtonActive;
	bool paused;

	void Start () 
	{
		bestScore = 0;

		initializeSingleRoundVariables ();

		Cursor.SetCursor (mouseTexture, cursorOffset, cursorMode);

//		Cursor.visible = false;
//		Cursor.lockState = CursorLockMode.Confined;

		StartCoroutine (SpawnEnemies());
	}

	void Update()
	{
		if (restartButtonActive) 
		{
			if 
			(
				Input.GetKeyDown (KeyCode.R) 
				|| Input.GetKeyDown (KeyCode.Return) 
				|| Input.GetKeyDown (KeyCode.Space)
			) { restartGame ();}
		} 
		else if (Input.GetKeyUp (KeyCode.Escape) || Input.GetKeyUp(KeyCode.P)) 
		{
			if (!paused) {
				pauseGame ();
			} else {
				unpauseGame ();
			}
		}
	}

	IEnumerator SpawnEnemies()
	{
		yield return new WaitForSeconds (waitBeforeSpawnStart);

		while (!gameOver)
		{
			yield return new WaitForSeconds(spawnInterval);

			int diceRoll = Random.Range (0, 4);
			string EnemySpawnTag = "EnemySpawn";

			switch (diceRoll) {
			case 0:
				EnemySpawnTag += "Top";
				break;
			case 1:
				EnemySpawnTag += "Bottom";
				break;
			case 2:
				EnemySpawnTag += "Left";
				break;
			case 3:
				EnemySpawnTag += "Right";
				break;
			}

			GameObject enemySpawn = GameObject.FindWithTag (EnemySpawnTag);

			MissileSpawner enemySpawner = enemySpawn.GetComponent<MissileSpawner> ();

			if (Random.value < missileToTankRatio)
				enemySpawner.spawnMissile ();
			else
				enemySpawner.spawnTank ();
		}

	}

	/* Game over is a coroutine just so it can wait a few seconds 
	 * before displaying the game over message
	 */ 

	public void GameOver()
	{
		gameOver = true;
		StartCoroutine (gameOverCoroutine ());
	}

	IEnumerator gameOverCoroutine()
	{
		yield return new WaitForSeconds (2f);
		gameOverText.text = "Game Over!";
		pauseText.text = "";
		gameOverSubtext.text = "Your Score: " + score + "\n";
		gameOverSubtext.text += "Best: " + bestScore + "\n\n";
		gameOverSubtext.text += "Press 'R' or 'Space' to restart";

		restartButtonActive = true;
	}

	public void addScore(int addedScore)
	{
		score += addedScore;

		if (score > bestScore) 
		{
			bestScore = score;
		}

		updateScoreText ();
	}

	void updateScoreText()
	{
		scoreText.text = "Score: " + score + "\n";
		scoreText.text += "Best: " + bestScore;
	}

	void pauseGame()
	{
		paused = true;
//		Cursor.visible = true;
//		Cursor.lockState = CursorLockMode.None;
		Cursor.SetCursor (null, Vector2.zero, cursorMode);

		gameOverText.text = "Paused";
		Time.timeScale = 0;
		if (playerInstance != null) {	// Player may have been destroyed
			Shooting shootingScript = playerInstance.GetComponentInChildren<Shooting> ();
			shootingScript.enabled = false;
		}


	}

	void unpauseGame()
	{
		paused = false;
//		Cursor.visible = false;
//		Cursor.lockState = CursorLockMode.Confined;
		Cursor.SetCursor (mouseTexture, cursorOffset, cursorMode);

		gameOverText.text = "";
		Time.timeScale = 1;
		if (playerInstance != null) {
			Shooting shootingScript = playerInstance.GetComponentInChildren<Shooting> ();
			shootingScript.enabled = true;
		}

	}

	/**
	 * Initializes the variables for a single round of play without dying
	 * Some variables are to be carried over from round to round after dying
	 * and are noy initialized in this function but instead on Start()
	 */ 
	void initializeSingleRoundVariables()
	{
		gameOver = false;
		restartButtonActive = false;
		paused = false;
		score = 0;
		updateScoreText ();

		gameOverText.text = "";
		gameOverSubtext.text = "";
		pauseText.text = "'Esc' or 'P' to pause";

		playerInstance = Instantiate (playerPrefab);
	}

	void destroyAllEnemies()
	{
		GameObject[] enemies = GameObject.FindGameObjectsWithTag ("Enemies");
		for (int i = 0; i < enemies.Length; i++) 
		{
			Destroy (enemies [i]);
		}
	}

	void restartGame()
	{
		
		initializeSingleRoundVariables ();
		StartCoroutine (SpawnEnemies());
		destroyAllEnemies ();
	}

}
