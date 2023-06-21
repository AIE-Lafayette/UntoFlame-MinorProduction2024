using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnBehaviour : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Despawn trigger detected.");
        Destroy(collider.gameObject);
        
    }
}
