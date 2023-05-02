using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Mixlevels : MonoBehaviour
{
    [Header("MasterMixer")]
    public AudioMixer VolumG;
    [Header("Controles de Volumen")]
    public Slider VolumenGeneral;
    public Slider VolumenMusica;
    public Slider VolumenEfectos;
    public Slider VolumenVoces;
    public void SetMasterVolume(float MasterVolume)
    {
        VolumG.SetFloat("VolumeOfMaster", MasterVolume);
    }
    public void SetMusicVolume (float MusicVolume)
    {
        VolumG.SetFloat("VolumeOfMusic", MusicVolume);
    } 
    public void SetFXVolume (float fxVolume)
    {
        VolumG.SetFloat("VolumenFX", fxVolume);
    }
    public void SetVOXVolume(float VoxVolume)
    {
        VolumG.SetFloat("VolumenOfVoice", VoxVolume);
    }
    public void Reset()
    {
        VolumenGeneral.value = PlayerPrefs.GetFloat("VolumeOfMaster", 0f);
        VolumenMusica.value = PlayerPrefs.GetFloat("VolumeOfMusic", 0f);
        VolumenEfectos.value = PlayerPrefs.GetFloat("VolumenFX", 0f);
        VolumenVoces.value = PlayerPrefs.GetFloat("VolumenOfVoice", 0f);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
