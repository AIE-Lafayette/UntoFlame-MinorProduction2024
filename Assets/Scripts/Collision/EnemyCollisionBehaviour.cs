using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionBehaviour : MonoBehaviour
{
    [SerializeField]
    private bool _deathWall;

    /// <summary>
    /// Checks to see if the enemy has collided with a death wall
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        //If not...
        if (!collision.gameObject.CompareTag("Death Wall"))
            //return
            return;

        //If true...
        if (collision.gameObject.CompareTag("Death Wall"))
            //...set deathwall to true
            _deathWall = true;

        //If deathwall is true
        if (_deathWall == true)
        {
            //...set enemy to not active
            Destroy(gameObject);
        }

        if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }
}