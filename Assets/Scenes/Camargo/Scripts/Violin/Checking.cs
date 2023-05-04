using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.Serialization;
//camargo

public class Checking : MonoBehaviour
{
    [SerializeField] float ranckError; //Rango de error
    [SerializeField] float checkOutClip; //dependiendo de que tan bien lo haga el jugador, llegara a 1 que es el maximo
    [SerializeField] bool isGoodTiming = false;

    [SerializeField] bool isPlayingCorrectly = false;

    //VELOCIDAD DE EL ARCO DEL JUGADOR
    [SerializeField] int _AVERAGERANGE = 1;
    float distancePlayerPrev; //Velocidad actual del arco del jugador
    private List<float> speeds = new List<float>();
    private float playSpeed;

    //para mover y dar respuesta en la ui.
    [SerializeField] GameObject UIViolin;
    [SerializeField] RectTransform Guia;

    [SerializeField] Slider speedIndicatorSlider;

    [SerializeField] float MultiplicadorDeMovimiento;
    Vector3 VectorGuia = new Vector3(451.7f, 138f, 0f);
    [FormerlySerializedAs("whentCall")] public UnityEvent onSecuenceSuccesfullyPlayed;
    public UnityEvent onSuccesfullyPlayedNote;

    public float CheckOutClip { get => checkOutClip; }
    public bool IsGoodTiming { get => isGoodTiming; }
    public float RanckError { get => ranckError; }
    public bool IsPlayingCorrectly { get => isPlayingCorrectly; }

    [SerializeField] float maxSpeed = 0.04f;
    [SerializeField] float minSpeed = 0f;

    private void Update()
    {
        if (speeds.Count > _AVERAGERANGE)
        {
            speeds.RemoveAt(0);
        }
    }


    //funcion para checar que el jugador lo este haciendo bien.
    public bool CheckMusic(float distancePlayer, float movementSpeed, float TimeMusic, float TimeClip)
    {
        float sliderFillValue = Mathf.InverseLerp(minSpeed, maxSpeed, movementSpeed);
        speedIndicatorSlider.value = sliderFillValue;


        if (sliderFillValue > 0.03 && sliderFillValue < 0.5f)
        {
            isPlayingCorrectly = true;
        }
        else
        {
            isPlayingCorrectly = false;
        }

        print(movementSpeed);

        if (checkOutClip > 1f)
        {
            isGoodTiming = true;
        }
        Debug.Log("wawawaw");
        if (checkRackAceptable(distancePlayer, movementSpeed, TimeMusic, TimeClip))
        {
            Debug.Log("si funciona?");
            checkOutClip += Time.deltaTime; // TimeClip;
            return true;
        }

        

        return false;
    }

    //funcion que se encarga de chequear si esta dentro de los rangos aceptables de movimiento el arco.
    private bool checkRackAceptable(float CorrectSpeed, float DistancePlayer, float TimeMusic, float TimeClip)
    {
        if (DistancePlayer < (CorrectSpeed + ranckError) && DistancePlayer > (CorrectSpeed - ranckError))
        {
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

    //
    public void AppearUIViolin()
    {
        UIViolin.SetActive(true);
    }

    public void DisappearUIViolin()
    {
        UIViolin.SetActive(false);
    }
}
