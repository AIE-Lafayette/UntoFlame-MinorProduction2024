using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility.ObjectPool;

public delegate void ChunkEvent(GameObject chunk);

public class ChunkSpawnerBehaviour : MonoBehaviour
{

    private static ChunkSpawnerBehaviour _instance;

    public void AddChunkDespawnListener(ChunkEvent listener) => _chunkDespawn += listener;
    public void AddChunkSpawnListener(ChunkEvent listener) => _chunkSpawn += listener;
    private int _currentComplexityIndex = 0;


    [SerializeField, Tooltip("The map chunks that will be spawned in.")]
    private ChunkBehavior[] _mapChunk;


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

    private int GetNext()
    {
        _currentComplexityIndex += 1;
        if (_currentComplexityIndex > GameManager.Instance.MapComplexityModifier)
        {
            _currentComplexityIndex = GameManager.Instance.MapComplexityModifier;
        }

        return _currentComplexityIndex;
    }

    public void SpawnChunk()
    {
        int randomNumber = Random.Range(0, _mapChunk.Length);

        Vector3 spawnPosition = new Vector3(Mathf.Floor(transform.position.x), transform.position.y, transform.position.z);

        Instantiate(_mapChunk[randomNumber].Chunks[GetNext()], spawnPosition, Quaternion.identity);


    }
}
