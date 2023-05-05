using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameObject Player;
	public static int Score = 0;
	public static float GameSpeedMultiplier = 1;

	[SerializeField]
	private GameObject _playerReference;

	private float timePassed;

	void Awake()
	{
		Player = _playerReference;
	}

	private void Update() 
	{
		timePassed += Time.deltaTime;
		if (timePassed > 1)
		{
			timePassed = 0;
			
			if (GameSpeedMultiplier < 5)
				GameSpeedMultiplier += 0.01f;

			Score += 1 * (int)GameSpeedMultiplier;
		}

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}
	}
}
