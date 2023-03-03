using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePositionArco : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] float PositionArcoToCamera = 0.04992065f;
    [SerializeField] float positiony = 0.2428903f;
    [SerializeField] private float speed;
    private float lastPosition;

    public float Speed { get => speed;}

    private void Update()
    {
        speed = (cam.ScreenToViewportPoint(Input.mousePosition).x - lastPosition) / Time.deltaTime;
        lastPosition = cam.ScreenToViewportPoint(Input.mousePosition).x;

        transform.localPosition = new Vector3((-1)*cam.ScreenToViewportPoint(Input.mousePosition).x, positiony, PositionArcoToCamera);
    }
}
