using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility.ObjectPool;

public delegate void ChunkEvent(GameObject chunk);

public class ChunkSpawnerBehaviour : SpawnerBehaviour
{
    private int _currentComplexityIndex = 0;
    [SerializeField, Tooltip("The screen boundary in scene that this script will look at in order to determine when to spawn a new mapChunk.")]
    private ScreenBoundaryBehaviour _screenBoundary;
    
    [SerializeField]
    private ChunkHolder_SO[] _chunkObjects;

    void Start()
    {
        SpawnItem();
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

    public override void SpawnItem()
    {
        GameObject[] chunks = _chunkObjects[GetNext()].Chunks;
        int randomNumber = Random.Range(0, chunks.Length);

        Vector3 spawnPosition = new Vector3(Mathf.Floor(transform.position.x), transform.position.y, transform.position.z);
       
        Instantiate(chunks[randomNumber], spawnPosition, Quaternion.identity);
    }

}
