using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllingBehaviour : MonoBehaviour
{
    [SerializeField, Tooltip("The variable that determines camera movement speed.")] private float speed = 5f;

    [SerializeField, Tooltip("The rigidbody of the gameObject that this script will be attached to.")] private Rigidbody _rigidBody;

    private bool _shouldCameraMove = true;

    // Update is called once per frame
    void Update()
    {

        if(!_shouldCameraMove)
        {
            return;
        }

        //Move the camera body to the right of the screen.
        _rigidBody.velocity = new Vector3(speed, 0, 0);

        GameManager.Instance.Score.Value = System.Convert.ToInt32(transform.localPosition.x);

        GameManager.Instance.Player.GetComponent<DamageBehavior>().AddDeathEventListener(_ =>
        {
            _shouldCameraMove = false;
        });
    }
}
