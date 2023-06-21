using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationBehaviour : MonoBehaviour
{
    Animator _animator;

    [SerializeField]
    private PlayerMovementBehaviour _movementBehaviour;
    [SerializeField]
    private PlayerSweepBehaviour _sweepBehaviour;
    [SerializeField]
    private DamageBehavior _damageBehaviour;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _animator.SetBool("Sweep", _sweepBehaviour.IsSweeping);
        _animator.SetBool("InAir", !_movementBehaviour.IsGrounded);
        _animator.SetFloat("Speed", _movementBehaviour.MoveDirection.magnitude);
    }
}
