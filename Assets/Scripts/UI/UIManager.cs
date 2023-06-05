using UnityEngine;
using UnityEngine.UI;   
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class UIManager : MonoBehaviour
{

    [SerializeField, Tooltip("A list of text objects that display the score.")]
    private Text[] _scoreTexts;

	[SerializeField, Tooltip("A list of text objects that displays the high score.")]
	private Text[] _highScoreTexts;

	[SerializeField, Tooltip("The game object that is displayed when the player dies.")]
	private GameObject _gameOverScreen;
	[SerializeField, Tooltip("The game object that is displayed when the player pauses the game.")]
	private GameObject _pauseScreen;

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
	/// Resumes gameplay, resetting time scale back to 1.
	/// </summary>
	public void Resume()
	{
		Time.timeScale = 1;
	}

	/// <summary>
	/// Exits the application.
	/// </summary>
	public void Quit()
	{
		Application.Quit();
	}

	/// <summary>
	/// Returns the player to the start menu, resetting the time scale and setting their high score.
	/// </summary>
	public void ReturnToStart()
	{		
		Resume();
		SceneManager.LoadScene(0);
	}

	/// <summary>
	/// Calls the Game Manager's StartGame method.
	/// </summary>
	public void StartGame()
	{	
		GameManager.Instance.StartGame();
	}

	/// <summary>
	/// Updates the high score text box with the high score from the GameManager.
	/// </summary>
	private void UpdateHighScoreText()
	{
		for (int i = 0; i < _highScoreTexts.Length; i++)
		{
			_highScoreTexts[i].text = "High Score: " + GameManager.Instance.HighScore.Value.ToString();
		}
	}

	/// <summary>
	/// Updates the score text box with the score from the GameManager.
	/// </summary>
	private void UpdateScoreText()
	{
		for (int i = 0; i < _scoreTexts.Length; i++)
		{
			_scoreTexts[i].text = "Score: " + GameManager.Instance.Score.Value.ToString();
		}
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
			GameManager.Instance.Player.GetComponent<DamageBehavior>().AddDeathEventListener(_=>{
				_gameOverScreen.SetActive(true);

				UpdateHighScoreText();
			}); 
	}

	private void Start()
	{
		for (int i = 0; i < _highScoreTexts.Length; i++)
		{
			_highScoreTexts[i].text = "High Score: " + GameManager.Instance.HighScore.Value.ToString();
		}
	}

    private void Update()
    {
		UpdateScoreText();
    }
}
