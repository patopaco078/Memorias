using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metronome : MonoBehaviour, IInteractable
{
    [SerializeField] private BoxCollider collider;
    [SerializeField] private ParticleSystem particles;
    [SerializeField] private GameObject metronomeDisplay;
    [SerializeField] private EnableViolin _enableViolin;
    
    public void Interact()
    {
        collider.enabled = false;
        particles.Stop();
        metronomeDisplay.SetActive(true);
        FogController.instance.AddFog();
        _enableViolin.Interacted();
    }
}
