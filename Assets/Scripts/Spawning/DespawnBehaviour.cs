using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnBehaviour : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Despawn collision detected.");
        if(collision.gameObject.CompareTag("Platform"))
        {
            Destroy(collision.gameObject);
        }
    }
}
