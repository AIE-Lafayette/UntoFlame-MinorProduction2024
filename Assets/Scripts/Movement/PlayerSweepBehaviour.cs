using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(DamageBehavior))]
public class PlayerSweepBehaviour : MonoBehaviour
{
    private PlayerMovementBehaviour _moveBehaviour;

    private float _invincibilityTime;
    private float _elapsedTime = 0;
    
    public bool IsSweeping = false;

    DamageBehavior _damageBehavior;

    private void Start()
    {
        _damageBehavior = GetComponent<DamageBehavior>();
    }

    private void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
            IsSweeping = true;
        }

        if(IsSweeping == true)
        {
            _damageBehavior.SetIsInvincible(true);

            _elapsedTime += Time.deltaTime;

        }
        if(_elapsedTime >= _invincibilityTime)
        {
            _damageBehavior.SetIsInvincible(false);

            IsSweeping = false;
        }
    }
}