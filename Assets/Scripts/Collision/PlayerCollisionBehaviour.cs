using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionBehaviour : MonoBehaviour
{
    [SerializeField]
    private bool _isEnemy;
    [SerializeField]
    private float _scoreMultiplier = 3;    
    [SerializeField]
    private bool _deathWall;

    public float Score;
    public Transform SpawnPoint;

    // Update is called once per frame
    void Update()
    {
        //Checks to make sure the player hasn't collided with an enemy
        if (!_isEnemy)
        {
            //If the haven't, their score will increase
            Score += _scoreMultiplier * Time.deltaTime;
        }
    }

    /// <summary>
    /// Checks to see if the player has collided with an enemy
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        //If the enemy has collided with the player...
        if (collision.gameObject.CompareTag("Enemy"))
            //...set isEnemy to be true
            _isEnemy = true;

        //If isEnemy is true...
        if (_isEnemy == true)
        {
            //...set player active to false
            gameObject.SetActive(false);
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }        
    }

    public void Knockback(float knockbackForce, Vector3 knockbackDirection)
    {
        gameObject.GetComponent<Rigidbody>().AddForce(knockbackDirection * knockbackForce, ForceMode.Impulse);
    }

    /// <summary>
    /// Function responsible for the player's respawn
    /// </summary>
    public void Respawn()
    {
        if (Input.GetKeyDown(KeyCode.R))
        { 
            //Resets the player's boolean that says they've collided with an enemy
            _isEnemy = false;

            //Sets the player to be active again
            gameObject.SetActive(true);

            //Has the player spawn at a predetermined location
            transform.position = SpawnPoint.position;

            //Resets the score to 0
            Score = 0;
        }
           
    }
}