using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

//Nico

public class NieblaYViolin : MonoBehaviour
{
    [SerializeField] float durationOfTransition = 10f;
    [SerializeField] private Material mistMaterial; //Material con el Shader de la niebla
    private float startTime = 0.0f; 
    private float alpha = 1.0f;
    private float timeOfTransition = 0.0f; 
    
    [SerializeField] private UnityEvent doThisWhenActivateMist;
    [SerializeField] private UnityEvent doThisWhenMistEnd;

    private void Start()
    {
        mistMaterial = GetComponent<Renderer>().material;
        startTime = Time.time;
    }

    private void Update()
    {
        timeOfTransition  = (Time.time - startTime) / durationOfTransition;
        alpha = Mathf.Lerp(1f, 0f, timeOfTransition );
        mistMaterial.SetFloat("Vector1_5a3d200a9ae8451e9b76f30e27f2c0a6", alpha); 
        //El nombre largo y feo es el que tenía por defecto el float alpha en el shadergraph
        //Deberías de revisar eso para ca,biarlo en un futuro
    }

    public void FadeMistIn()
    {
        timeOfTransition  = (Time.time - startTime) / durationOfTransition;
        alpha = Mathf.Lerp(1f, 0f, timeOfTransition );
        mistMaterial.SetFloat("Vector1_5a3d200a9ae8451e9b76f30e27f2c0a6", alpha); 
        //El nombre largo y feo es el que tenía por defecto el float alpha en el shadergraph
        //Deberíamos de revisar eso para cambiarlo en un futuro
        doThisWhenActivateMist.Invoke();
    }
    
    public void FadeMistOut()
    {
        timeOfTransition  = (Time.time - startTime) / durationOfTransition;
        alpha = Mathf.Lerp(0f, 1f, timeOfTransition );
        mistMaterial.SetFloat("Vector1_5a3d200a9ae8451e9b76f30e27f2c0a6", alpha); 
        //El nombre largo y feo es el que tenía por defecto el float alpha en el shadergraph
        //Deberíamos de revisar eso para cambiarlo en un futuro
        doThisWhenMistEnd.Invoke();
    } 

}
