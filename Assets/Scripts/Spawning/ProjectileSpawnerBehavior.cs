using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility.ObjectPool;

public class ProjectileSpawnerBehavior : MonoBehaviour
{
    [SerializeField, Tooltip("The projectile that is fired towards the player.")]
    private GameObject _projectile;
    [SerializeField, Tooltip("The speed at which the projectile moves in units per frame.")]
    private float _projectileSpeed;
    [SerializeField, Tooltip("How often the bullet should spawn in seconds. Does not apply if auto fire is disabled.")]
    private float  _projectileSpawnRate;

    [SerializeField, Tooltip("If enabled, the projectile will fire automatically.")]
    private bool _shouldAutoFire;

    public bool ShouldAutoFire
    {
        get { return _shouldAutoFire; }
        set { _shouldAutoFire = value; }
    }

    public void Fire()
    {
        GameObject projectile = ObjectPoolBehavior.Instance.GetObject(_projectile, transform.position, transform.rotation);
        Vector3 direction = (transform.position - GameManager.Instance.Player.transform.position).normalized;
        projectile.GetComponent<Rigidbody>().velocity = (direction*-1) * _projectileSpeed;
    }

    float elapsedTime;
    private void Update()
    {
        if (!_shouldAutoFire) return;

        elapsedTime += Time.deltaTime;
        if (elapsedTime >= _projectileSpawnRate)
        {
            elapsedTime = 0;
            Fire();
        }
    }
}
