using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class ColorRandomizer : MonoBehaviour
{
    const int MinColorHue = 0;
    const int MaxColorHue = 1;
    const int Saturation = 1;
    const int Brightness = 1;

    private MeshRenderer _meshRenerer;

    private void Awake()
    {
        _meshRenerer = GetComponent<MeshRenderer>();
        _meshRenerer.material.color = Random.ColorHSV(MinColorHue, MaxColorHue, Saturation, Saturation, Brightness, Brightness);
    }
}
