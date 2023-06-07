using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedSpawnerBehaviour : ChunkSpawnerBehaviour
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
            SpawnChunk();
            _currentTimeToSpawn = _timeToSpawn;
        }
    }
}
