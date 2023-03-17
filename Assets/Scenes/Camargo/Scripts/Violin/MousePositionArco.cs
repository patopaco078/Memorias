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
    [SerializeField] private bool isTouchViolin = false;

    public float Speed { get => speed;}
    public bool IsTouchViolin { get => isTouchViolin;}

    private void Update()
    {
        speeds.Add((transform.localPosition.x - lastPosition) / Time.deltaTime);

        if(speeds.Count > TotalPromedioSpeeds)
        {
            speeds.RemoveAt(0);
        }

        speed = promedioPositions();

        lastPosition = transform.localPosition.x;

        transform.localPosition = new Vector3((-1)*cam.ScreenToViewportPoint(Input.mousePosition).x, positiony, PositionArcoToCamera);
    }

    //funcion necesaria para que el programa no arroje falsos positivos
    private float promedioPositions()
    {
        float sumatoria = 0;
        for(int i = 0; i < speeds.Count; i++)
        {
            sumatoria += speeds[i];
        }
        return sumatoria / TotalPromedioSpeeds;
    }

    //se llama esto cuando el jugador esta tocando el violin con el arco
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Violin")
            isTouchViolin = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Violin")
            isTouchViolin = false;
    }
}
