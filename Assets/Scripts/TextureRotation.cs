using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureRotation : MonoBehaviour
{
    Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        RotateTextureHorizontally();
    }

    void RotateTextureHorizontally()
    {
        rend.material.mainTextureScale = new Vector2(1, 90); // Adjust the tiling to rotate 90 degrees
    }
}
