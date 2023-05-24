using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void DamageEvent();

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
    /// Applies damage and optional knockback to the object, as well as enables invincibility on the object. Will reset velocity before applying force.
    /// </summary>
    /// <param name="knockbackDirection">The direction to knock the object towards.</param>
    /// <param name="knockbackForce">The force to apply to the  object. Uses impulse ForceMode. Defaults to Zero.</param>
    public void ApplyDamage(Vector3 knockbackDirection, float knockbackForce=0)
    {
        _rigidbody.velocity = Vector3.zero;
		_rigidbody.AddForce(knockbackDirection * knockbackForce, ForceMode.Impulse);

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
