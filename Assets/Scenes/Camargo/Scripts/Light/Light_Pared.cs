using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Light_Pared : MonoBehaviour
{
    [SerializeField] GameObject[] Lights;
    private AudioSource LightSound;

    private void Start()
    {
        TurnOffLights();
        LightSound = GetComponent<AudioSource>();
    }

    public void TurnOnLights()
    {
        LightSound.Play();
        for (int i = 0; i < Lights.Length; i++)
        {
            Lights[i].SetActive(true);
        }
    }

    public void TurnOffLights()
    {
        for (int i = 0; i < Lights.Length; i++)
        {
            Lights[i].SetActive(false);
        }
    }
}
