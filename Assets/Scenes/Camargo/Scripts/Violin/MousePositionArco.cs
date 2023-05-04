using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//camargo

public enum MovementDirection
{
    Left = 0,
    Right = 1,
    None = 2
}

public class MousePositionArco : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] float PositionArcoToCamera = 0.04992065f;
    [SerializeField] float positiony = 0.2428903f;
    [SerializeField] private float speed;
    private List<float> speeds = new List<float>();
    private Vector3 lastPosition;
    [SerializeField] private int TotalPromedioSpeeds = 3;
    [SerializeField] private bool isTouchViolin = false;

    private Vector3 startPosition;

    public float Speed { get => speed;}
    public bool IsTouchViolin { get => isTouchViolin;}
    public Vector3 StartPosition { get => startPosition; }
    public Transform ActualPosition { get => transform; }

    MovementDirection movementDir;
    public MovementDirection MovementDir { get => movementDir; }

    Checking checkingCode;
    MusicController musicController;

    bool flag_CheckedViolinStopPlayed = false;

    private void Start()
    {
        checkingCode = transform.parent.GetComponentInChildren<Checking>();
        musicController = transform.parent.GetComponentInChildren<MusicController>();
    }

    private void Update()
    {
        speeds.Add(Vector3.Distance(transform.localPosition, lastPosition) / Time.deltaTime);

        if(speeds.Count > TotalPromedioSpeeds)
        {
            speeds.RemoveAt(0);
        }

        speed = promedioPositions();

        float xDirection = lastPosition.x - transform.localPosition.x;

        movementDir = xDirection > 0 ? MovementDirection.Right : MovementDirection.Left;

        lastPosition = transform.localPosition;

        transform.localPosition = new Vector3((-1)*cam.ScreenToViewportPoint(Input.mousePosition).x, positiony, PositionArcoToCamera);


        // Verificar en que momento terminamos de tocar el violin de forma erronea

        if (!isTouchViolin)
        {
            if (flag_CheckedViolinStopPlayed)
            {
                return;
            }


            if (!checkingCode.IsPlayingCorrectly)
            {
                musicController.ResetPlayingSequence();
            }

            flag_CheckedViolinStopPlayed = true;
        }
        else if (isTouchViolin && flag_CheckedViolinStopPlayed)
        {
            flag_CheckedViolinStopPlayed = false;
        }
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
        {
            isTouchViolin = true;
            startPosition = transform.position;
        }
            
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Violin")
            isTouchViolin = false;
    }
}
