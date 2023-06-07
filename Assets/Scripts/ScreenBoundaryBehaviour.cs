using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility.ObjectPool;

public class ScreenBoundaryBehaviour : MonoBehaviour
{

    [SerializeField]
    private ChunkSpawnerBehaviour _chunkSpawner;
    private void OnTriggerExit(Collider other)
    {
        Destroy(other.transform.parent.gameObject);
        _chunkSpawner.SpawnChunk();
    }

}
