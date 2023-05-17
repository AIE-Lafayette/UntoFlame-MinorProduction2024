using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ObjectPool;

public delegate void ChunkEvent(GameObject chunk);

public class ChunkSpawnerBehaviour : MonoBehaviour
{
    private ChunkEvent _chunkDespawn;
    private ChunkEvent _chunkSpawn;

    public void AddChunkDespawnListener(ChunkEvent listener) => _chunkDespawn += listener;
    public void AddChunkSpawnListener(ChunkEvent listener) => _chunkSpawn += listener;


    [SerializeField, Tooltip("The map chunks that will be spawned in.")]
    private GameObject[] _mapChunk;

    [SerializeField]
    private ScreenBoundaryBehaviour _screenBoundary;

    // Start is called before the first frame update
    void Start()
    {
        SpawnChunk();
    }

    // Update is called once per frame
    void Update()
    {
        if (ScreenBoundaryBehaviour._canSpawn)
            SpawnChunk();
    }

    void SpawnChunk()
    {
        int randomNumber = Random.Range(0, _mapChunk.Length - 1);

        GameObject chunk = ObjectPoolBehaviour.Instance.GetObject(_mapChunk[randomNumber], transform.position, Quaternion.identity);

        ScreenBoundaryBehaviour._canSpawn = false;
    }
}
