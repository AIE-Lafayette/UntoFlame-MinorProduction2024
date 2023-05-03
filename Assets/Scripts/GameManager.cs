using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	[Tooltip("The player object.")]
	public GameObject Player;

	[Tooltip("The game score.")]
	public int Score = 0;

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

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}
	}
}
