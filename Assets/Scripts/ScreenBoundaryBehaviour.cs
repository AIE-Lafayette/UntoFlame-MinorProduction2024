using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility.ObjectPool;

public class ScreenBoundaryBehaviour : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        Destroy(other.transform.parent.gameObject);
        ChunkSpawnerBehaviour.Instance.SpawnChunk();
    }

}
