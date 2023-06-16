using UnityEngine;

public class InteractableBehaviour : MonoBehaviour
{
    [SerializeField, Tooltip("The amount to rotate the object by. This adds to its current rotation.")]
    private Vector3 _rotation;

    [SerializeField]
    private float _speed;
 
    private Vector3 _startRotation;
    private Vector3 _finalRotation;

    private bool _shouldMove;

    private float _time;

    public void Interact()
    {
        _canCollide = false;
        _shouldMove = true;
    }

    private void Start()
    {
        _finalRotation = transform.localEulerAngles + _rotation;
        _startRotation = transform.localEulerAngles;
    }

    private void Update()
    {
        if (!_shouldMove) return;

        _time += Time.deltaTime * _speed;

        transform.localRotation = Quaternion.Lerp(Quaternion.Euler(_startRotation), Quaternion.Euler(_finalRotation), _time);

        if (transform.localRotation == Quaternion.Euler(_finalRotation))
            _shouldMove = false;
    }
}
