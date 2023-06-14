using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsManager : MonoBehaviour
{
    private ScreenShakeBehavior _screenShake;
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

    
}
