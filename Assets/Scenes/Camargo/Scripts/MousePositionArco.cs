using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePositionArco : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] float PositionArcoToCamera = 0.04992065f;
    [SerializeField] float positiony = 0.2428903f;

    private void Update()
    {
        transform.localPosition = new Vector3((-1)*cam.ScreenToViewportPoint(Input.mousePosition).x, positiony, PositionArcoToCamera);
    }
}
