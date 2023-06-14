using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ChunkHolder", menuName = "ChunkHolder")]
public class ChunkHolder_SO : ScriptableObject
{
    [SerializeField]
    private GameObject[] _chunks;

    public GameObject[] Chunks
    {
        get { return _chunks; }
        set { _chunks = value; }
    }
}
