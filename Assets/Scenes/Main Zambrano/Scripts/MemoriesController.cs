using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class MemoriesController : MonoBehaviour
{
    public static MemoriesController instance;
    
    [SerializeField] private VideoPlayer reproductor;

    [SerializeField] private VideoClip memory1;
    [SerializeField] private VideoClip memory2;
    [SerializeField] private VideoClip memory3;
    [SerializeField] private VideoClip memory4;
    [SerializeField] private VideoClip memory5;

    [SerializeField] private PuertaSala puertaSala;

    [SerializeField] private GameObject PauseMenu;

    private void Awake()
    {
        if (instance)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    public void OpenPauseMenu()
    {
        PauseMenu.SetActive(true);
    }
    
    private void Start()
    {
        reproductor.loopPointReached += CloseReproductor;
    }


    public void PlayMemory(int memoryId)
    {
        reproductor.gameObject.SetActive(true);
        switch (memoryId)
        {
            case 0:
                reproductor.clip = memory1;
                puertaSala.OpenDoor();
                break;
            case 1:
                reproductor.clip = memory2;
                break;
            case 2:
                reproductor.clip = memory3;
                FogController.instance.AddFog();
                FogController.instance.AddFog();
                FogController.instance.AddFog();
                break;
            case 3:
                reproductor.clip = memory4;
                break;
            case 4:
                reproductor.clip = memory5;
                break;
            
        }
        
        reproductor.Play();
        PlayerMovementZambrano.instance.enabled = false;
        CameraMovementZambrano.instance.ignoreMousePos = true;
    }

    private void CloseReproductor(VideoPlayer videoEvent)
    {
        reproductor.Stop();
        reproductor.gameObject.SetActive(false);
        
        PlayerMovementZambrano.instance.enabled = true;
        CameraMovementZambrano.instance.ignoreMousePos = false;
    }
}
