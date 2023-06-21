using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SweepArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        CompareTag(other.tag);

        if(tag == "Interactable")
        {
            InteractableBehaviour behaviour = other.GetComponent<InteractableBehaviour>();

            if (!behaviour) return;

            behaviour.Interact();
        }
    }
}
