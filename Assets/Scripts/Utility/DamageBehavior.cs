using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class DamageBehavior : MonoBehaviour
{
    private bool _isInvincible = false;
    private Rigidbody _rigidbody;

    [SerializeField, Tooltip("The amount of time the object is invincible after taking damage.")]
    private float _invincibilityTime;
    private float _elapsedTime = 0;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public bool IsInvincible {
        get { return _isInvincible; }
        private set { _isInvincible = value; }
    }

    /// <summary>
    /// Applies a knockback to the object, as well as enables invincibility on the object. Will reset velocity before applying force.
    /// </summary>
    /// <param name="direction">The direction to knock the object towards.</param>
    /// <param name="force">The force to apply to the  object. Uses impulse ForceMode.</param>
    public void ApplyKnockback(Vector3 direction, float force)
    {
        _rigidbody.velocity = Vector3.zero;
		_rigidbody.AddForce(direction * force, ForceMode.Impulse);
        IsInvincible = true;
    }

    /// <summary>
    /// Checks if the object is invincible, and if so, updates the elapsed time. If the elapsed time is greater than the invincibility time, the object is no longer invincible.
    /// </summary>
    void Update()
    {
        if (IsInvincible)
        {
            _elapsedTime += Time.deltaTime;
            if (_elapsedTime >= _invincibilityTime)
            {
                _elapsedTime = 0;
                IsInvincible = false;
            }
        }
    }



}
