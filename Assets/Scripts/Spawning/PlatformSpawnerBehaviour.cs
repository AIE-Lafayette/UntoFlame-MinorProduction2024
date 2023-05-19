using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawnerBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject _ground1, _ground2, _ground3;

    bool _hasGround = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!_hasGround)
        {
            SpawnPlatform();
            _hasGround = true;
        }
        
    }

    public void SpawnPlatform()
    {
        Debug.Log("A platform has been spawned.");
        int randomNum = Random.Range(1, 4);
        Debug.Log(randomNum);

        if(randomNum == 1)
        {
            Instantiate(_ground1, new Vector3(transform.position.x - 5, 2, 0), Quaternion.identity);
        }

        if (randomNum == 2)
        {
            Instantiate(_ground1, new Vector3(transform.position.x - 5, 0, 0), Quaternion.identity);
        }

        if (randomNum == 3)
        {
            Instantiate(_ground1, new Vector3(transform.position.x - 5, -2, 0), Quaternion.identity);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("A trigger has been entered.");
        if(collision.gameObject.CompareTag("Platform"))
        {
            _hasGround = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        Debug.Log("A trigger has been exited.");
        //if(collision.gameObject.CompareTag("Platform"))
        //{
        //    Debug.Log("does not have ground");
        //    _hasGround = false;

        //}

        _hasGround = false;
    }
}
