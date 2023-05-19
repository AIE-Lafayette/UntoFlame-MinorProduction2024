using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformControllingBehaviour : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private Rigidbody _rigidBody;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        _rigidBody.velocity = new Vector3( -1 * speed, 0, 0);   
    }
}
