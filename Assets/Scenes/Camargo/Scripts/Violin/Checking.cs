using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//camargo

public class Checking : MonoBehaviour
{
    [SerializeField] float ranckError; //Rango de error
    [SerializeField] float checkOutClip; //dependiendo de que tan bien lo haga el jugador, llegara a 1 que es el maximo
    [SerializeField] bool IsGoodTiming = false; //

    public float CheckOutClip { get => checkOutClip; }
    public bool IsGoodTiming1 { get => IsGoodTiming; }

    public void CheckMusic(float Distances, float DistancePlayer, float TimeMusic, float TimeClip)
    {
        float ActualDistanceCorrect = Distances * (TimeMusic / TimeClip);

        if(DistancePlayer < (ActualDistanceCorrect + ranckError) && DistancePlayer > (ActualDistanceCorrect - ranckError))
        {
            checkOutClip += Time.deltaTime / TimeClip;
        }

        if(TimeMusic >= TimeClip && DistancePlayer > (Distances - ranckError))
        {
            IsGoodTiming = true;
        }
    }

    public void ResetCheckOutClip()
    {
        checkOutClip = 0f;
        IsGoodTiming = false;
    }
}
