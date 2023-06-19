using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	[SerializeField, Tooltip("The player object.")]
	private GameObject _player;

	[SerializeField, Tooltip("The score.")]
	private Integer_SO _score;

	[SerializeField, Tooltip("The high score.")]
	private Integer_SO _highScore;
	
	private int _mapComplexityModifier = 0;

	private float _gameSpeedMultiplier = 1;

	public GameObject Player
	{
		get {return _player;}
	}

	public Integer_SO Score
	{
		get {return _score;}
		set {_score = value;}
	}

	public Integer_SO HighScore
	{
		get {return _highScore;}
		set {_highScore = value;}
	}

	public int MapComplexityModifier
	{
		get {return _mapComplexityModifier;}
		set {_mapComplexityModifier = value;}
	}

	public float GameSpeedMultiplier
	{
		get {return _gameSpeedMultiplier;}
	}
	
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
	/// 
	public void StartGame()
	{
		SceneManager.LoadScene(2);
		// Reset the score
		Score.Value = 0;

		// Reset the game speed
		_gameSpeedMultiplier = 1;
	}

	private void UpdateComplexityModifier()
	{
		int modifier = Mathf.FloorToInt(Score.Value / 300);

		if (modifier > 2)
			modifier = 2;

		if (modifier > MapComplexityModifier)
		{
			_gameSpeedMultiplier = 1 + (modifier * 0.1f);
			MapComplexityModifier = modifier;
		}
	}

	private float timePassed;

	void Start()
	{
		if (SceneManager.GetActiveScene().buildIndex == 0)
		{
			HighScore.Value = 0;
			SceneManager.LoadScene(1);
		}

	}
	
	private void Update() 
	{
		timePassed += Time.deltaTime;
		if (timePassed > 1)
		{
			timePassed = 0;
			if (_gameSpeedMultiplier < 5)
				_gameSpeedMultiplier += 0.01f;
		}
		if ((Score != null && HighScore != null) && Score.Value > HighScore.Value)
			HighScore.Value = Score.Value;

		UpdateComplexityModifier();
	}
}
