using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSweepBehaviour : MonoBehaviour
{
    private PlayerMovementBehaviour _moveBehaviour;

    public bool IsSweeping;


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
            _moveBehaviour.IsSweeping = true;
        }

        if(IsSweeping == true)
        {
            gameObject.SetActive(true);
        }
    }
}
