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
            //...set "IsGrounded" to be true
            IsGrounded = true;
            _moveBehaviour._numberOfJumps = 2;
        }
    }

    /// <summary>
    /// Determines what happens when the exits the ground collider
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        //When the player leaves the ground...
        if (other.CompareTag("Ground"))
        {
            //...set "IsGrounded" to be false
            IsGrounded = false;
        }

    }
}