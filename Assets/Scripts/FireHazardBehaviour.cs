using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireHazardBehaviour : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<DamageBehavior>().Kill();
        }
    }
}
