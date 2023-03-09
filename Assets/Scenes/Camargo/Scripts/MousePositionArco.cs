using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//camargo
public class MousePositionArco : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] float PositionArcoToCamera = 0.04992065f;
    [SerializeField] float positiony = 0.2428903f;
    [SerializeField] private float speed;
    private List<float> speeds = new List<float>();
    private float lastPosition;
    [SerializeField] private int TotalPromedioSpeeds = 3;

    public float Speed { get => speed;}

    private void Update()
    {
        speeds.Add((transform.localPosition.x - lastPosition) / Time.deltaTime);

        if(speeds.Count > TotalPromedioSpeeds)
        {
            speeds.RemoveAt(0);
        }

        speed = promedioPositions();

        //Debug.Log(speeds.Count + " speed = " + speeds[0]);
        lastPosition = transform.localPosition.x;

        transform.localPosition = new Vector3((-1)*cam.ScreenToViewportPoint(Input.mousePosition).x, positiony, PositionArcoToCamera);
    }

    private float promedioPositions()
    {
        float sumatoria = 0;
        for(int i = 0; i < speeds.Count; i++)
        {
            sumatoria += speeds[i];
        }
        return sumatoria / TotalPromedioSpeeds;
    }
}
