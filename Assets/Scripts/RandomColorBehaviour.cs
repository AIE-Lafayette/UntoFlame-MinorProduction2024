using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColorBehaviour : MonoBehaviour
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
}
