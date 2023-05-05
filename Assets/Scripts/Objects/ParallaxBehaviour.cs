using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBehaviour : MonoBehaviour
{
    [SerializeField] private float _depth = 1;

    private void Awake()
    {
        //Find the gameObject Player
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;

        pos.x -= Time.fixedDeltaTime / _depth;

        transform.position = pos;
    }
}
