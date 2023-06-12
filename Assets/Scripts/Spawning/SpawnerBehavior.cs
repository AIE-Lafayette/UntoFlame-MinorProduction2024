using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBehavior : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _items;

    public List<GameObject> Items
    {
        get { return _items; }
        set { _items = value; }
    }

    public virtual void SpawnItem()
    {
        int randomNumber = Random.Range(0, _items.Count);

        Vector3 spawnPosition = new Vector3(Mathf.Floor(transform.position.x), transform.position.y, transform.position.z);

        Instantiate(_items[randomNumber], spawnPosition, Quaternion.identity);
    }
}
