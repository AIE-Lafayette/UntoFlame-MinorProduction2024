using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    [SerializeField , Tooltip("The amount of time (in seconds) that the screen shakes for.")]
    private float _shakeDuration;
    [SerializeField, Tooltip("The magnitude at which the sreeen shakes.")]
    private float _shakeMagnitude;
    [SerializeField]
    private float _fadeInTime;
    [SerializeField]
    private float _fadeOutTime;
    private float _tick;
    private float _currentFadeTime;
    private bool _sustain = false;
    private bool _running;

    private void Start()
    {
        _tick = Random.Range(-100f, 100f);
        _sustain = (_fadeInTime > 0);
        _currentFadeTime = (_fadeInTime > 0) ? 0 : 1;
    }

    public Vector3 UpdateShake(float dt)
    {
        Vector3 offset = new Vector3(
            Mathf.PerlinNoise(_tick, 0) * 0.5f,
            Mathf.PerlinNoise(0, _tick) * 0.5f,
            Mathf.PerlinNoise(_tick, _tick) * 0.5f
        );


        if (_fadeInTime > 0 && _sustain)
        {
            if (_currentFadeTime < 1)
                _currentFadeTime += (dt / _fadeInTime);
            else if (_fadeOutTime > 0)
                _sustain = false;
        }

        if (!_sustain)
        {
            _currentFadeTime -= (dt / _fadeOutTime);
        }
        else
        {
            _tick += dt * _currentFadeTime;
        }

        return offset * _shakeMagnitude * _currentFadeTime;
    }

    public bool IsShaking()
    {
        return _currentFadeTime > 0 || _sustain;
    }

    public void StartFadeIn(float fadeInTime)
    {
        if (fadeInTime == 0)
            _currentFadeTime = 1;
        
        _fadeInTime = fadeInTime;
        _fadeOutTime = 0;  
        _sustain = true;
    }

    public void StartFadeOut(float fadeOutTime)
    {
        if (fadeOutTime == 0)
            _currentFadeTime = 0;
        
        _fadeOutTime = fadeOutTime;
        _fadeInTime = 0;
        _sustain = false;
    }
}
