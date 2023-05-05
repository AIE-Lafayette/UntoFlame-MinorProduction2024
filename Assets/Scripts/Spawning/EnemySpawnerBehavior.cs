using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerBehavior : MonoBehaviour
{
    [SerializeField, Tooltip("The enemies that will be spawned in the level.")]
    private GameObject[] _enemies;
    void Start()
    {
        int randomNumber = Random.Range(0, _enemies.Length - 1);

        GameObject enemy = Instantiate(_enemies[randomNumber], transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
