using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehaviour : MonoBehaviour
{    
    /// <summary>
     /// Determines what happens when the enters the ground collider
     /// </summary>
     /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        //If the player is on the ground...
        if (other.CompareTag("Enemy"))
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
