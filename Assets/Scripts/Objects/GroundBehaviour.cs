using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundBehaviour : MonoBehaviour
{

    private float _groundHeight;
    private float _groundRight;
    private float _screenRight;

    BoxCollider _collider;

    bool _didGenerateGround = false;

    private void Awake()
    {
        _collider = GetComponent<BoxCollider>();
        _groundHeight = transform.position.y + (_collider.size.y / 2);
        _screenRight = Camera.main.transform.position.x * 2;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _groundRight = transform.position.x + (_collider.size.x / 2);
        if (!_didGenerateGround)
        {

            if (_groundRight < _screenRight)
            {
                _didGenerateGround = true;
                GenerateGround();
            }

        }
    }

    void GenerateGround()
    {
        GameObject ground = Instantiate(gameObject);
        BoxCollider groundCollider = ground.GetComponent<BoxCollider>();
        Vector2 pos;
        pos.x = _screenRight + 30;
        pos.y = transform.position.y;
        ground.transform.position = pos;
    }
}
