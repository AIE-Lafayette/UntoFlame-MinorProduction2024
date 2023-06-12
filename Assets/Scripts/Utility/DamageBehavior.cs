using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility.ObjectPool;



[RequireComponent(typeof(Rigidbody))]
public class DamageBehavior : MonoBehaviour
{
    public delegate void DamageEvent(DamageBehavior damageBehavior);

    private bool _isInvincible = false;
    private Rigidbody _rigidbody;

    [SerializeField, Tooltip("The amount of time the object is invincible after taking damage.")]
    private float _invincibilityTime;
    private float _elapsedTime = 0;

    private DamageEvent damageEvent;
    private DamageEvent deathEvent;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public bool IsInvincible {
        get { return _isInvincible; }
        private set { _isInvincible = value; }
    }

    public void SetIsInvincible(bool isInvincible)
    {
        IsInvincible = isInvincible;
        _elapsedTime = 0;
    }

    public void AddDamageEventListener(DamageEvent listener)
    {
        damageEvent += listener;
    }

    public void AddDeathEventListener(DamageEvent listener)
    {
        deathEvent += listener;
    }



    /// <summary>
    /// Applies damage and optional knockback to the object, as well as enables invincibility on the object. Will reset velocity before applying force.
    /// </summary>
    /// <param name="knockbackDirection">The direction to knock the object towards.</param>
    /// <param name="knockbackForce">The force to apply to the  object. Uses impulse ForceMode. Defaults to Zero.</param>
    public void ApplyDamage(Vector3 knockbackDirection, float knockbackForce=0)
    {
        if (IsInvincible) return;

        _rigidbody.velocity = Vector3.zero;
		_rigidbody.AddForce(knockbackDirection * knockbackForce, ForceMode.Impulse);

        IsInvincible = true;

        if (damageEvent != null)
            damageEvent.Invoke(this);
    }

    /// <summary>
    /// Kills the gameobject.
    /// </summary>
    public void Kill()
    {
        if (deathEvent != null)
            deathEvent.Invoke(this);
        
        gameObject.SetActive(false);
            
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
