using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSweepBehaviour : MonoBehaviour
{
    private PlayerMovementBehaviour _moveBehaviour;

    public bool IsSweeping = false;


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
            IsSweeping = true;

            //gameObject.GetComponent<PlayerPrefs>(gameObject.PlayerCapeSweep);
            gameObject.SetActive(true);
        }

        if(IsSweeping == true)
        {
            gameObject.SetActive(true);
            gameObject.GetComponent<Collider>().enabled = true;
        }
    }
}
