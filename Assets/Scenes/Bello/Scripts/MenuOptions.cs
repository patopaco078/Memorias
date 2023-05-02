using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MenuOptions : MonoBehaviour
{
    public AudioMixer VolumG;
    public AudioMixerGroup VolumM;
    public AudioMixerGroup VolumE;
    public AudioMixerGroup VolumV;
    public Slider VolumenGeneral;
    public Slider VolumenMusica;
    public Slider VolumenEfectos;
    public Slider VolumenVoces;
    /*public void FullScreen(bool fullScreen)
    {
        Screen.fullScreen = fullScreen;
    }

    void LoadState()
    {
        VolumenGeneral.value = PlayerPrefs.GetFloat("VolumenGeneral", 1f);
        VolumenMusica.value = PlayerPrefs.GetFloat("VolumenMusica", 1f);
        VolumenEfectos.value = PlayerPrefs.GetFloat("VolumenEfectos", 1f);
        VolumenVoces.value = PlayerPrefs.GetFloat("VolumenVoces", 1f);
    }
    public void ChangeVolumen(float volumen1, float volumen2, float volumen3, float volumen4)
    {
        VolumG.SetFloat("Volumen", volumen1);
        VolumM.SetFloat("Volumen", volumen2);
        VolumE.SetFloat("Volumen", volumen3);
        VolumV.SetFloat("Volumen", volumen4);
    }*/
}
