using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

//Nico

public class NieblaYViolin : MonoBehaviour
{
    [SerializeField] private Material mistMaterial; //Material con el Shader de la niebla
    [SerializeField] float durationOfTransition = 10f;
    
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
        mistMaterial.SetFloat("_alpha", alpha);
    }

    public void FadeMistIn()
    {
        timeOfTransition  = (Time.time - startTime) / durationOfTransition;
        alpha = Mathf.Lerp(1f, 0f, timeOfTransition );
        mistMaterial.SetFloat("_alpha", alpha);
        doThisWhenActivateMist.Invoke();
    }
    
    public void FadeMistOut()
    {
        timeOfTransition  = (Time.time - startTime) / durationOfTransition;
        alpha = Mathf.Lerp(0f, 1f, timeOfTransition );
        mistMaterial.SetFloat("_alpha", alpha);
        doThisWhenMistEnd.Invoke();
    } 

}
