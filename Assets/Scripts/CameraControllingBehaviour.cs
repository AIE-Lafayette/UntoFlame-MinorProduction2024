using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllingBehaviour : MonoBehaviour
{
    [SerializeField, Tooltip("Adjustable value that determines how fast the camera moves to the right.")] private float speed = 5f;

    [SerializeField] private Rigidbody _rigidBody;

    // Update is called once per frame
    void Update()
    {
        //Move the camera body to the right of the screen.
        _rigidBody.velocity = new Vector3(1 * speed, 0, 0);
    }
}
