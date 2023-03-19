using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//camargo

public class Checking : MonoBehaviour
{
    [SerializeField] float ranckError; //Rango de error
    [SerializeField] float checkOutClip; //dependiendo de que tan bien lo haga el jugador, llegara a 1 que es el maximo
    [SerializeField] bool isGoodTiming = false; //

    //para mover y dar respuesta en la ui.
    [SerializeField] RectTransform Guia;
    [SerializeField] float MultiplicadorDeMovimiento;
    Vector3 VectorGuia = new Vector3(451.7f, 138f, 0f);

    public float CheckOutClip { get => checkOutClip; }
    public bool IsGoodTiming { get => isGoodTiming; }
    public float RanckError { get => ranckError; }

    //funcion para checar que el jugador lo este haciendo bien.
    public bool CheckMusic(float Distances, float DistancePlayer, float TimeMusic, float TimeClip)
    {
        Guia.position = VectorGuia;
        float ActualDistanceCorrect = Distances * (TimeMusic / TimeClip);
        VectorGuia.y = ((DistancePlayer - ActualDistanceCorrect) * MultiplicadorDeMovimiento) + 138f;
        if (DistancePlayer < (ActualDistanceCorrect + ranckError) && DistancePlayer > (ActualDistanceCorrect - ranckError))
        {
            checkOutClip += Time.deltaTime / TimeClip;
            return true;
            
        }
        else
        {
            return false;
        }

        if(TimeMusic >= TimeClip && DistancePlayer > (Distances - ranckError))
        {
            isGoodTiming = true;
        }
    }

    //funcion para reiniciar el sistema | en caso de que lo haga mal o termine de tocar.
    public void ResetCheckOutClip()
    {
        checkOutClip = 0f;
        isGoodTiming = false;
    }
}
