using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShakeBehavior : MonoBehaviour
{
	[SerializeField , Tooltip("The amount of time (in seconds) that the screen shakes for.")]
	private float _shakeDuration;
	[SerializeField, Tooltip("The magnitude at which the sreeen shakes.")]
	private float _shakeMagnitude;
	[SerializeField, Tooltip("The frequency at which the screen shakes.")]
	private float _shakeFrequency;
	[SerializeField, Tooltip("The amount of time (in seconds) that the screen takes to fade into full speed.")]
	private float _fadeInDuration;
	[SerializeField, Tooltip("The amount of time (in seconds) that the screen takes to fade out of full speed.")]
	private float _fadeOutDuration;
	private float _tick;
	private float _currentFadeTime;
	private bool _sustain = false;
	private bool _isShaking = false;
	private Vector3 _initialRotation;
	private float _elapsedTime;

	private int negativeOffset = 1;


	private void Start()
	{
		_tick = Random.Range(-1f, 1f);
		_sustain = (_fadeInDuration > 0);
		_currentFadeTime = (_fadeInDuration > 0) ? 0 : 1;
		
		_initialRotation = transform.localEulerAngles;

		if (_fadeInDuration <= 0)
			_fadeOutDuration = 1;
	}

	/// <summary>
	/// Updates the shake effect with a new noise offset.
	/// </summary>
	/// <returns>The shake offset to apply to the camera.</returns>
	private Vector3 UpdateShake()
	{
		float dt = Time.deltaTime;

		Vector3 offset = new Vector3(
			Mathf.PerlinNoise(_tick, 0),
			Mathf.PerlinNoise(0, _tick),
			Mathf.PerlinNoise(_tick, _tick)
		).normalized;


		if (_fadeInDuration > 0 && _sustain)
		{
			if (_currentFadeTime < 1)
				_currentFadeTime += (dt / _fadeInDuration);
			else if (_fadeOutDuration > 0)
				_sustain = false;
		}

		if (!_sustain)
		{
			_currentFadeTime -= (dt / _fadeOutDuration);
			_tick += dt * _shakeFrequency * _currentFadeTime;  
		}
		else
		{
			_tick += dt * _shakeFrequency;
		}

		return offset * (negativeOffset *= -1) * _shakeMagnitude * _currentFadeTime;
	}

	/// <summary>
	/// Starts the fade in effect given a fade-in time and sets the current fade time.
	/// </summary>
	/// <param name="fadeInTime">The duration to set.</param>
	private void StartFadeIn(float fadeInTime)
	{
		if (fadeInTime == 0)
			_currentFadeTime = 1;
		
		_fadeInDuration = fadeInTime;
		_fadeOutDuration = 0;  
		_sustain = true;
	}

	/// <summary>
	/// Starts the fade out effect given a fade-out time and sets the current fade time.
	/// </summary>
	/// <param name="fadeOutTime">The duration to set.</param>
	private void StartFadeOut(float fadeOutTime)
	{
		if (fadeOutTime == 0)
			_currentFadeTime = 0;
		
		_fadeOutDuration = fadeOutTime;
		_fadeInDuration = 0;
		_sustain = false;
	}

	/// <summary>
	/// Starts the camera shake with pre-set settings.
	/// </summary>
	public void StartShake()
	{
		if (_isShaking) return;

		_isShaking = true;

	}

	/// <summary>
	/// Starts the camera shake with a set of given settings.
	/// </summary>
	/// <param name="duration">How long the camera should shake for.</param>
	/// <param name="magnitude">How intense the shake is on the camera.</param>
	/// <param name="frequency">The frequency at which the camera shakes.</param>
	/// <param name="fadeInTime">The amount of time in seconds to reach full speed.</param>
	/// <param name="fadeOutTime">The amount of time in seconds to fade out of full speed.</param>

	public void StartShake(float duration, float magnitude, float frequency, float fadeInTime, float fadeOutTime)
	{
		if (_isShaking) return;

		_isShaking = true;
		
		_shakeDuration = duration;
		_shakeMagnitude = magnitude;
		_shakeFrequency = frequency;
		_fadeInDuration = fadeInTime;
		_fadeOutDuration = fadeOutTime;
	}

	/// <summary>
	/// Starts the camera shake with a sustained effect, using preset settings.
	/// </summary>
	public void ShakeSustain()
	{
		if (_isShaking) return;

		_isShaking = true;

		StartFadeIn(_fadeInDuration);
	}

	/// <summary>
	/// Starts the camera shake with a sustained effect, using the given settings.
	/// </summary>
	/// <param name="duration">How long the camera should shake for.</param>
	/// <param name="magnitude">How intense the shake is on the camera.</param>
	/// <param name="frequency">The frequency at which the camera shakes.</param>
	/// <param name="fadeInTime">The amount of time in seconds to reach full speed.</param>
	/// <param name="fadeOutTime">The amount of time in seconds to fade out of full speed.</param>
	public void ShakeSustain(float duration, float magnitude, float frequency, float fadeInTime, float fadeOutTime)
	{
		if (_isShaking) return;

		_isShaking = true;
		
		_shakeDuration = duration;
		_shakeMagnitude = magnitude;
		_shakeFrequency = frequency;
		_fadeInDuration = fadeInTime;
		_fadeOutDuration = fadeOutTime;

		StartFadeIn(_fadeInDuration);
	}

	/// <summary>
	/// Stops the camera shake.
	/// </summary>
	public void StopShake()
	{
		if (!_isShaking) return;

		_isShaking = false;

		transform.localEulerAngles = _initialRotation;
	}

	/// <summary>
	/// Stops the camera shake with a fade-out effect.
	/// </summary>
	/// <param name="duration">The fade-out duration.</param>
	public void StopSustained(float duration)
	{
		if (_fadeOutDuration == 0)
			StartFadeOut(duration);

		transform.localEulerAngles = _initialRotation;
	}

	/// <summary>
	/// Stops the camera shake with a fade-out effect, using the fade-in duration.
	/// </summary>
	public void StopSustained()
	{
		if (_fadeOutDuration == 0)
			StartFadeOut(_fadeInDuration);
	}

	private void FixedUpdate()
	{
		if (!_isShaking) return;

		// initialize the position and rotation offsets
		Vector3 rotAddShake = Vector3.one;

		Vector3 shake = Vector3.Scale( UpdateShake(), new Vector3(0,0,1));

		rotAddShake = Vector3.Scale(rotAddShake, shake);

		transform.localEulerAngles = _initialRotation + rotAddShake;

		_initialRotation = transform.localEulerAngles - rotAddShake;
		

		_elapsedTime += Time.deltaTime;


		// if the shake duration is greater than 0 and the elapsed time is greater than the shake duration, reset the elapsed time and stop the shake.
		if (_shakeDuration > 0  && _elapsedTime >= _shakeDuration)
		{
			_elapsedTime = 0;
			if (!_sustain)
				StopShake();
			else
				StopSustained();
		}
	}
}