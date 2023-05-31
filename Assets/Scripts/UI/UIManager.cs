using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   

public class UIManager : MonoBehaviour
{

    [SerializeField]
    private Text _scoreText;
	private GameObject _gameOverScreen;

	private static UIManager _instance;
	public static UIManager Instance
	{
		get
		{
			if (!_instance)
				_instance = FindObjectOfType<UIManager>();

			if (!_instance)
			{
				Debug.Log("No UIManager found in scene. Creating one.");
				_instance = new GameObject("UIManager").AddComponent<UIManager>();
			}

			return _instance;
		}
	}

	private void Awake()
	{
		if (_gameOverScreen)
			GameManager.Instance.Player.GetComponent<DamageBehavior>().AddDeathEventListener(_=>_gameOverScreen.SetActive(true)); 
	}

    private void Update()
    {
        _scoreText.text = "Score: " + GameManager.Instance.Score.ToString();
    }
}
