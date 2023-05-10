using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ProjectileSpawnerBehavior))]
public class EnemyShooterBehavior : MonoBehaviour
{
    private ProjectileSpawnerBehavior _projectileSpawner;

    [SerializeField, Tooltip("The range at which the enemy will start firing at the player. If set to -1, the enemy will fire at the player regardless of range.")]
    private float _range = -1;

    [SerializeField, Tooltip("The rate at which the enemy will fire at the player in seconds.")]
    private float _fireRate;


    void Awake()
    {
        _projectileSpawner = GetComponent<ProjectileSpawnerBehavior>();
        _projectileSpawner.ShouldAutoFire = false;
    }

    float elapsedTime = 0;
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if ((Vector3.Distance(transform.position, GameManager.Instance.Player.transform.position) <= _range || _range < 0)
            && elapsedTime >= _fireRate)
        {
            elapsedTime = 0;
            _projectileSpawner.Fire();
        }
        
    }
}
