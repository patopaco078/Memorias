using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogController : MonoBehaviour
{
    public static FogController instance;
    
    [SerializeField] private ParticleSystem fogParticles;

    [SerializeField] private GameObject violinIcon;

    private int fogLevel;

    public bool canPlay;

    public bool haveViolin;

    public bool canDicipate;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }

        canDicipate = true;
    }

    public void AddFog()
    {
        fogLevel++;
        if (fogLevel > 3)
        {
            fogLevel = 3;
        }
        var emission = fogParticles.emission;
        switch (fogLevel)
        {
            case 1:
                emission.rateOverTime = 1;
                break;
            case 2:
                emission.rateOverTime = 6;
                break;
            case 3:
                emission.rateOverTime = 10;
                if(haveViolin)
                    violinIcon.SetActive(true);
                canPlay = true;
                break;
        }
    }

    public void ReduceFog()
    {
        if(!canDicipate)
            return;
        
        fogLevel--;

        if (fogLevel < 0)
        {
            fogLevel = 0;
        }
        var emission = fogParticles.emission;
        switch (fogLevel)
        {
            case 0:
                emission.rateOverTime = 0;
                break;
            case 1:
                emission.rateOverTime = 1;
                break;
            case 2:
                emission.rateOverTime = 6;
                break;
            case 3:
                emission.rateOverTime = 10;
                break;
        }
    }
}
