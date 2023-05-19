using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBoundaryBehaviour : MonoBehaviour
{
    public static bool _canSpawn;

    private void OnTriggerExit(Collider other)
    {
        _canSpawn = true;
    }
    // Start is called before the first frame update
    void Start()
    {
           
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
