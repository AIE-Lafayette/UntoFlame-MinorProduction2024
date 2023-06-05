using UnityEngine;
using UnityEngine.UI;   
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class UIManager : MonoBehaviour
{

    [SerializeField]
    private Text _scoreText;

	[SerializeField]
	private Text _highScoreText;

	[SerializeField]
	private GameObject _gameOverScreen;
	[SerializeField]
	private GameObject _pauseScreen;

	[SerializeField]
	private GameObject _eventSystem;

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
	
	/// <summary>
	/// Resumes gameplay.
	/// </summary>
	public void Resume()
	{
		Time.timeScale = 1;
	}

	/// <summary>
	/// Quits the game.
	/// </summary>
	public void Quit()
	{
		Application.Quit();
	}

	/// <summary>
	/// Returns to the start menu.
	/// </summary>
	public void ReturnToStart()
	{	
		if (GameManager.Instance.Score.Value > GameManager.Instance.HighScore.Value)
			GameManager.Instance.HighScore.Value = GameManager.Instance.Score.Value;
			
		Resume();
		SceneManager.LoadScene(0);
	}

	/// <summary>
	/// Starts the game.
	/// </summary>
	public void StartGame()
	{	
		GameManager.Instance.StartGame();
	}

	/// <summary>
	/// Pauses the game and shows the pause screen if it exists.
	/// </summary>
	public void Pause()
	{
		if(!_pauseScreen) return;
		_pauseScreen.SetActive(!_pauseScreen.activeSelf);

		if (_pauseScreen.activeSelf)
		{
			Time.timeScale = 0;
			InputSystem.settings.updateMode = InputSettings.UpdateMode.ProcessEventsInDynamicUpdate;
		}
		else
		{
			Time.timeScale = 1;
			InputSystem.settings.updateMode = InputSettings.UpdateMode.ProcessEventsInFixedUpdate;
		}
	}

	private void Awake()
	{
		if (_gameOverScreen)
			GameManager.Instance.Player.GetComponent<DamageBehavior>().AddDeathEventListener(_=>_gameOverScreen.SetActive(true)); 
	}

	private void Start()
	{
		if (_eventSystem)
			_eventSystem.SetActive(true);

		if (_highScoreText)
			_highScoreText.text = "High Score: " + GameManager.Instance.HighScore.Value.ToString();
	}

    private void Update()
    {
		if(_scoreText)
        	_scoreText.text = "Score: " + GameManager.Instance.Score.Value.ToString();
    }
}
