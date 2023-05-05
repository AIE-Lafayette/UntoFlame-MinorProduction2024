using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementBehaviour : MonoBehaviour
{
    private Rigidbody _rb;
    private Vector2 _moveDirection;

    [SerializeField]
    private float _acceleration;
    [SerializeField]
    public float _numberOfJumps = 2;
    [SerializeField]
    private float _maxSpeed;
    [SerializeField]
    private float _jumpPower;
    [SerializeField]
    private GroundColliderBehaviour _groundCollider;

    // Start is called before the first frame update

    void Start()
    {
        //Assigns a rigidbody at the start of the program
        _rb = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// Future function for future projects
    /// </summary>
    ///   <param name="direction"></param>
    public void SetMoveDirection(Vector3 direction)
    {
        _moveDirection = direction;
    }

    //Function that is called when the player jumps.
    public void Jump()
    {
        //Checks to see if the player is on the ground or has an extra jump
        if (_groundCollider.IsGrounded || _numberOfJumps > 0)
        { 
            //If so, allow the player to jump
            _rb.AddForce(Vector3.up * _jumpPower, ForceMode.VelocityChange);
        
            _numberOfJumps--;
        }
    }

    // Update is called once per frame

    private void FixedUpdate()
    {
        //Allows for the player's acceleration to be modified in unity
        float acceleration = _acceleration;

        //Only allows the player to move forward if the player is on the ground
        if (_groundCollider.IsGrounded)
        _rb.AddForce(_moveDirection * acceleration * Time.deltaTime, ForceMode.VelocityChange);
                
    }
}
