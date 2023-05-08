using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawnerBehavior : MonoBehaviour
{
    [SerializeField]
    private GameObject _projectile;
    [SerializeField]
    private float _projectileSpeed;
    [SerializeField]
    private float _projectileLifetime;
    [SerializeField]
    private float  _projectileSpawnRate;


    private float _elapsedTime;
    void Update()
    {
        _elapsedTime += Time.deltaTime;
        if (_elapsedTime >= _projectileSpawnRate)
        {
            _elapsedTime = 0;
            GameObject projectile = Instantiate(_projectile, transform.position, transform.rotation);
            Vector3 direction = (transform.position - GameManager.Instance.Player.transform.position).normalized;
            projectile.GetComponent<Rigidbody>().velocity = (direction*-1) * _projectileSpeed;
            Destroy(projectile, _projectileLifetime);
        }
    }
}
