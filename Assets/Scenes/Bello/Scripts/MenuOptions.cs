using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MenuOptions : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    public void FullScreen(bool fullScreen)
    {
        Screen.fullScreen = fullScreen;
    }
    public void ChangeVolumen(float volumen)
    {
        audioMixer.SetFloat("Volumen", volumen);
    }
}
