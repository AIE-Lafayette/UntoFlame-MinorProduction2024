using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementBehaviour : MonoBehaviour
{
    
    private Rigidbody _rb;
    private Vector3 _moveDirection;
    private Vector3 _jumpVelocity;

    [SerializeField]
    private bool _isSweeping = false;

    [Header("Player Speeds")]
    [Tooltip("Controls the speed of the player while on the ground.")]
    [SerializeField]
    private float _groundSpeed;
    [Tooltip("Controls the speed of the player while in the air.")]
    [SerializeField]
    private float _airSpeed;

    [Header("Player Jumps")]
    [Tooltip("Determines how high the player jumps")]
    [SerializeField]
    private float _jumpPower;
    [Tooltip("How many times the player can jump before hitting the ground.")]
    [SerializeField]
    private bool _hasDoubleJump;


    public bool HasDoubleJump
    {
        get { return _hasDoubleJump; }
        set { _hasDoubleJump = value; }
    }

    public bool IsSweeping
    {
        get { return _isSweeping; }
        set { _isSweeping = value; }
    }

    [SerializeField]
    private GroundColliderBehaviour _groundCollider;

    // Start is called before the first frame update

    void Start()
    {
        //Assigns a rigidbody at the start of the program
        _rb = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// Allows the player's direction to be changed beased upon input.
    /// </summary>
    ///   <param name="direction">The direction that the player inputs</param>
    public void SetMoveDirection(Vector3 direction)
    {
        _moveDirection = direction;
    }

    /// <summary>
    /// Function that is called when the player jumps.
    /// </summary>
    public void Jump()
    {
        //Checks to see if the player is on the ground or has an extra jump
        if (_groundCollider.IsGrounded || _hasDoubleJump == true  )
        {
            //Force to adjust player by
            _jumpVelocity = new Vector3(0, 1, 0) * _jumpPower;

            //Adjusts the player position
            _rb.velocity = _jumpVelocity;

            //Removes the doublejump from the player
            _hasDoubleJump = false;
        }
    }
public void Sweep()
    {
        
        if (_isSweeping == true)
        {
            //DamageBehavior damageBehavior = new DamageBehavior();
            gameObject.SetActive(true);
        }

    }

    // Update is called once per frame

    private void FixedUpdate()
    {     
        
        //Controls the speed the player moves on ground
        if (_groundCollider.IsGrounded)
        {
            transform.position += _moveDirection * _groundSpeed * Time.deltaTime;
        }

        //Controls the speed the player moves in air
        if (!_groundCollider.IsGrounded)
        {
            transform.position += _moveDirection * _airSpeed * Time.deltaTime;
        }
                
    }
}
