using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsManager : MonoBehaviour
{
    private ScreenShakeBehavior _screenShake;

	public ScreenShakeBehavior ScreenShake
	{
		get { return _screenShake; }
		private set { _screenShake = value; }
	}

	private void Awake()
	{
		_screenShake = Camera.main.GetComponent<ScreenShakeBehavior>();

		if (!_screenShake)
			_screenShake = Camera.main.gameObject.AddComponent<ScreenShakeBehavior>();
	}

	private static EffectsManager _instance;
	public static EffectsManager Instance
	{
		get
		{
			if (!_instance)
				_instance = FindObjectOfType<EffectsManager>();

			if (!_instance)
			{
				Debug.Log("No EffectsManager found in scene. Creating one.");
				_instance = new GameObject("UIManager").AddComponent<EffectsManager>();
			}

			return _instance;
		}
	}

    
}
