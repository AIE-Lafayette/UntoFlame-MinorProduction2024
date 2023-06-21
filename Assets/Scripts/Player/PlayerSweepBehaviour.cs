using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(DamageBehavior))]
public class PlayerSweepBehaviour : MonoBehaviour
{
    private GameObject _sweepArea;
    [SerializeField]
    private GameObject _sweepEffect;
    
    private bool _isSweeping = false;

    private float _timeToSweep = 0.25f;
    private float _timer = 0f;

    private PlayerMovementBehaviour _moveBehaviour;

    private float _invincibilityTime;
    
    public bool IsSweeping
    {
        get { return _isSweeping; }
        private set { _isSweeping = value; }
    }

    public void SetIsSweeping(bool isSweeping)
    {
        _isSweeping = isSweeping;
    }

    DamageBehavior _damageBehavior;

    private void Start()
    {
        _sweepArea = transform.GetChild(0).gameObject;

        _damageBehavior = GetComponent<DamageBehavior>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
            Sweep();
        }

        if(_isSweeping)
        {   
            _damageBehavior.SetIsInvincible(true);
            _timer += Time.deltaTime;
            _sweepArea.SetActive(true);


            if (_timer >= _timeToSweep)
            {
                _timer = 0f;
                _isSweeping = false;
                _sweepArea.SetActive(false);
            }
        }
    }

    private void Sweep()
    {
        _isSweeping = true;
        _sweepArea.SetActive(_isSweeping);

        Instantiate(_sweepEffect, transform.position, _sweepEffect.transform.rotation);
    }
}