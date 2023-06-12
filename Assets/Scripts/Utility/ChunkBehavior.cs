using UnityEngine;

public class ChunkBehavior : MonoBehaviour
{
    [SerializeField, Tooltip("A list of chunks sorted by complexity. The first chunk is the simplest, the last chunk is the most complex.")]
    private GameObject[] _chunks;

    public GameObject[] Chunks
    {
        get { return _chunks; }
        set { _chunks = value; }
    }
}
