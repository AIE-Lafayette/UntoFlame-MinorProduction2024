using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	[Tooltip("The player object.")]
	public GameObject Player;

	[Tooltip("The game score.")]
	public Integer_SO Score;

	[Tooltip("The high score.")]
	public Integer_SO HighScore;

	public float GameSpeedMultiplier {get; private set;}

	private static GameManager _instance;
	public static GameManager Instance
	{
		get
		{
			if (!_instance)
				_instance = FindObjectOfType<GameManager>();

			if (!_instance)
			{
				Debug.Log("No GameManager found in scene. Creating one.");
				_instance = new GameObject("GameManager").AddComponent<GameManager>();
			}

			return _instance;
		}
	}

	/// <summary>
	/// Starts the game, loading the main scene and resetting the score and game speed multiplier.
	/// </summary>
	public void StartGame()
	{
		SceneManager.LoadScene(1);
		// Reset the score
		Score.Value = 0;

		// Reset the game speed
		GameSpeedMultiplier = 1;
	}

	private float timePassed;
	
	private void Update() 
	{
		timePassed += Time.deltaTime;
		if (timePassed > 1)
		{
			timePassed = 0;
			if (GameSpeedMultiplier < 5)
				GameSpeedMultiplier += 0.01f;
		}

		if (Score.Value > HighScore.Value)
			HighScore.Value = Score.Value;		
	}
}
