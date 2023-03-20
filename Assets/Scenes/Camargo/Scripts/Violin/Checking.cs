using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
//camargo

public class Checking : MonoBehaviour
{
    [SerializeField] float ranckError; //Rango de error
    [SerializeField] float checkOutClip; //dependiendo de que tan bien lo haga el jugador, llegara a 1 que es el maximo
    [SerializeField] bool isGoodTiming = false;

    //VELOCIDAD DE EL ARCO DEL JUGADOR
    [SerializeField] int _AVERAGERANGE = 1;
    float distancePlayerPrev; //Velocidad actual del arco del jugador
    private List<float> speeds = new List<float>();
    private float _DistancePlayer;

    //para mover y dar respuesta en la ui.
    [SerializeField] RectTransform BACK_Guia1;
    [SerializeField] RectTransform BAKC_Guia2;
    [SerializeField] RectTransform Guia;
    [SerializeField] float MultiplicadorDeMovimiento;
    Vector3 VectorGuia = new Vector3(451.7f, 138f, 0f);
    [SerializeField] UnityEvent whentCall;

    public float CheckOutClip { get => checkOutClip; }
    public bool IsGoodTiming { get => isGoodTiming; }
    public float RanckError { get => ranckError; }

    private void Start()
    {
        BACK_Guia1.position = new Vector3(451.7f, 238f, 0f);
        BAKC_Guia2.position = new Vector3(451.7f, 204f, 0f);
    }

    private void Update()
    {
        //speeds.Add();

        if (speeds.Count > _AVERAGERANGE)
        {
            speeds.RemoveAt(0);
        }
    }


    //funcion para checar que el jugador lo este haciendo bien.
    public bool CheckMusic(float CorrectSpeed, float DistancePlayer, float TimeMusic, float TimeClip)
    {
        _DistancePlayer = DistancePlayer;

        Guia.position = VectorGuia;
        VectorGuia.y = (DistancePlayer * MultiplicadorDeMovimiento) + 138f;
        if (checkOutClip > 1f)
        {
            isGoodTiming = true;
            whentCall.Invoke();
        }
        if (DistancePlayer < (CorrectSpeed + ranckError) && DistancePlayer > (CorrectSpeed - ranckError))
        {
            checkOutClip += Time.deltaTime; // TimeClip;
            return true;
        }

        

        return false;
    }

    //funcion para reiniciar el sistema | en caso de que lo haga mal o termine de tocar.
    public void ResetCheckOutClip()
    {
        checkOutClip = 0f;
        isGoodTiming = false;
    }

    private void FindOutSpeed(float DistancePlayer)
    {
        //NEW CODE

        float timeElapsed = Time.deltaTime;
        float distanceTraveled = Mathf.Abs(DistancePlayer - distancePlayerPrev);
        float currentSpeed = distanceTraveled / timeElapsed;
        distancePlayerPrev = DistancePlayer;
        Debug.Log(currentSpeed);
    }
}
