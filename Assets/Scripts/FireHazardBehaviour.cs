using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireHazardBehaviour : MonoBehaviour
{
    [SerializeField]
    private MeshRenderer _meshRenderer;

    private void Awake()
    {
        ChangeColor();
    }
    void ChangeColor()
    {
        _meshRenderer.material.color = Random.ColorHSV();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<DamageBehavior>().Kill();
        }
    }
}
