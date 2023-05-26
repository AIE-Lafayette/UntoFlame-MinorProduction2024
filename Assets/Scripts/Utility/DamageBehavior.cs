using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class DamageBehavior : MonoBehaviour
{
    private bool _isInvincible = false;

    private Rigidbody _rigidbody;

    [SerializeField]
    private float _InvincibilityTime;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public bool IsInvincible {
        get { return _isInvincible; }
        private set { _isInvincible = value; }
    }

    public void ApplyKnockback(Vector3 direction, float force)
    {
        _rigidbody.velocity = Vector3.zero;
		_rigidbody.AddForce(direction * force, ForceMode.Impulse);
        IsInvincible = true;
    }

    float _elapsedTime = 0;
    void Update()
    {
        if (IsInvincible)
        {
            _elapsedTime += Time.deltaTime;
            if (_elapsedTime >= _InvincibilityTime)
            {
                _elapsedTime = 0;
                IsInvincible = false;
            }
        }
    }



}
