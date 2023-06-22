using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedSpawnerBehaviour : SpawnerBehaviour
{
    [SerializeField]
    private float _timeToSpawn;

    private float _currentTimeToSpawn;

    // Update is called once per frame
    void Update()
    {
      if(_currentTimeToSpawn > 0)
        {
            _currentTimeToSpawn -= Time.deltaTime;
        }

        else
        {
            SpawnItem();
            _currentTimeToSpawn = _timeToSpawn;
        }
    }

    public override void SpawnItem()
    {
        int randomNumber = Random.Range(0, Items.Count);

        Vector3 spawnPosition = new Vector3(Mathf.Floor(transform.position.x), transform.position.y, transform.position.z);

        Instantiate(Items[randomNumber], spawnPosition, transform.rotation);
    }
}
