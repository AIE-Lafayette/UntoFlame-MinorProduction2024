using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility.ObjectPool;

public delegate void ChunkEvent(GameObject chunk);

public class ChunkSpawnerBehaviour : MonoBehaviour
{
    private ChunkEvent _chunkDespawn;
    private ChunkEvent _chunkSpawn;

    private static ChunkSpawnerBehaviour _instance;

    public void AddChunkDespawnListener(ChunkEvent listener) => _chunkDespawn += listener;
    public void AddChunkSpawnListener(ChunkEvent listener) => _chunkSpawn += listener;


    [SerializeField, Tooltip("The map chunks that will be spawned in.")]
    private GameObject[] _mapChunk;

    [SerializeField, Tooltip("The screen boundary in scene that this script will look at in order to determine when to spawn a new mapChunk.")]
    private ScreenBoundaryBehaviour _screenBoundary;

    public static ChunkSpawnerBehaviour Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<ChunkSpawnerBehaviour>();
            }

            if (_instance == null)
            {
                Debug.Log("No chunk spawner found in scene. Making chunk spawner.");
                GameObject chunkSpawner = new GameObject("ChunkSpawner");
                _instance = chunkSpawner.AddComponent<ChunkSpawnerBehaviour>();
            }

            return _instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        SpawnChunk();
    }

    public void SpawnChunk()
    {
        int randomNumber = Random.Range(0, _mapChunk.Length);

        Vector3 spawnPosition = new Vector3(Mathf.Floor(transform.position.x), transform.position.y, transform.position.z);

        Instantiate(_mapChunk[randomNumber], spawnPosition, Quaternion.identity);


    }
}
