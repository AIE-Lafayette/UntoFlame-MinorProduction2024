using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundColliderBehaviour : MonoBehaviour
{
    [SerializeField]
    private PlayerMovementBehaviour _moveBehaviour;

    public bool IsGrounded;

    /// <summary>
    /// Determines what happens when the enters the ground collider
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        //If the player is on the ground...
        if (other.CompareTag("Ground"))
        {
            Debug.Log("Grounded");
            //...set "IsGrounded" to be true..
            IsGrounded = true;
            //...as well as set the player to have a doublejump  
            _moveBehaviour._hasDoubleJump = true;
        }

        else
        {
            //...set "IsGrounded" to be false..
            IsGrounded = false;
        }
    }

    /// <summary>
    /// Determines what happens when the exits the ground collider
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        //When the player leaves the ground...
        
            //...set "IsGrounded" to be false
            IsGrounded = false;

        _moveBehaviour._hasDoubleJump = true;

    }
}