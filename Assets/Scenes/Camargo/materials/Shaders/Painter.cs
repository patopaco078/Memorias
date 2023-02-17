using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Camargo

public class Painter : MonoBehaviour
{
    [SerializeField] Texture2D texture;
    [SerializeField] Transform Target;
    private Color colorPaint = Color.white;

    private void Start()
    {
        texture.SetPixel((int)Target.position.x, (int)Target.position.z, colorPaint);
        texture.Apply();
    }

    private void Update()
    {
        texture.SetPixel((int)Target.position.x, (int)Target.position.z, colorPaint);
        texture.Apply();
    }
}
