using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class ColorRandomizer : MonoBehaviour
{
    const float MinColorValue = 0.5f;
    const float MaxColorValue = 1;

    private MeshRenderer _meshRenerer;

    private void Awake()
    {
        _meshRenerer = GetComponent<MeshRenderer>();

        float red = Random.Range(MinColorValue, MaxColorValue);
        float green = Random.Range(MinColorValue, MaxColorValue);
        float blue = Random.Range(MinColorValue, MaxColorValue);

        _meshRenerer.material.color = new Color(red, green, blue);
    }
}
