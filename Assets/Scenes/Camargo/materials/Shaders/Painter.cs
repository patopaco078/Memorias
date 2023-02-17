using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Camargo

public class Painter : MonoBehaviour
{
    [SerializeField] Texture2D texture;
    [SerializeField] Transform Target;
    [SerializeField] int ImageSize = 4;
    private Color colorPaint = Color.white;
    private Color colorBase = Color.black;

    private void Start()
    {
        for(int x = 0; x < ImageSize; x++)
        {
            for (int y = 0; y < ImageSize; y++)
            {
                texture.SetPixel(x, y, colorBase);
                texture.Apply();
            }
        }

        texture.SetPixel((int)Target.position.x * -1, (int)Target.position.z * -1, colorPaint);
        texture.Apply();
    }

    private void Update()
    {
        texture.SetPixel((int)Target.position.x * -1, (int)Target.position.z * -1, colorPaint);
        texture.Apply();
    }
}
