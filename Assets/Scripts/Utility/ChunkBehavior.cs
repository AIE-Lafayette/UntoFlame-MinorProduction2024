using UnityEngine;

public class Chunk : ScriptableObject
{
[SerializeField]
    private GameObject[] _chunks;

    public GameObject[] Chunks
    {
        get { return _chunks; }
        set { _chunks = value; }
    }
}
