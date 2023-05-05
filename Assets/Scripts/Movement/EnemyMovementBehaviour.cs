using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyMovementBehaviour : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [Tooltip("The object the enemy will be seeking towards.")]
    [SerializeField]
    private GameObject _target;
    [Tooltip("The maximum magnitude this enemy's velocity can have.")]
    [SerializeField]
    private float _maxVelocity;

    //Sets the target for the enemy. (Stretch goal to hyave the enemy intentionally target the player)
    public GameObject Target
    {
        get
        {
            return _target;
        }
        set
        {
            _target = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //Get a reference to the attached rigidbody
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        //If a target hasn't been set return
        if (!_target)
            return;

        _rigidbody.AddForce(Vector3.left * _maxVelocity);

        //If the velocity goes over the max magnitude, clamp it
        if (_rigidbody.velocity.magnitude > _maxVelocity)
            _rigidbody.velocity = _rigidbody.velocity.normalized * _maxVelocity;
    }
}
