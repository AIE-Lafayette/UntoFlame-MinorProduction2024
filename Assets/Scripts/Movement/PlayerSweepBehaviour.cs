using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(DamageBehavior))]
public class PlayerSweepBehaviour : MonoBehaviour
{
    private GameObject _sweepArea = default;
    
    public bool IsSweeping = false;

    private float _timeToSweep = 0.25f;
    private float _timer = 0f;

    //private PlayerMovementBehaviour _moveBehaviour;

    //private float _invincibilityTime;
    //private float _elapsedTime = 0;
    
    

    DamageBehavior _damageBehavior;

    private void Start()
    {
        _sweepArea = transform.GetChild(0).gameObject;

        //_damageBehavior = GetComponent<DamageBehavior>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
            Sweep();
        }

        if(IsSweeping)
        {
            _timer += Time.deltaTime;

            if(_timer >= _timeToSweep)
            {
                _timer = 0f;
                IsSweeping = false;
                _sweepArea.SetActive(IsSweeping);
            }
        }

        //if(IsSweeping == true)
        //{
        //    _damageBehavior.SetIsInvincible(true);

        //    _elapsedTime += Time.deltaTime;

        //}
        //if(_elapsedTime >= _invincibilityTime)
        //{
        //    _damageBehavior.SetIsInvincible(false);

        //    IsSweeping = false;
        //}
    }

    private void Sweep()
    {
        IsSweeping = true;
        _sweepArea.SetActive(IsSweeping);
    }
}