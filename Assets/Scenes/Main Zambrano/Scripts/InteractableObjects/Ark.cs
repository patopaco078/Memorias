using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ark : MonoBehaviour, IInteractable
{
    [SerializeField] private BoxCollider _collider;
    [SerializeField] private ParticleSystem particles;
    [SerializeField] private GameObject arkDisplay;
    [SerializeField] private EnableViolin _enableViolin;
    public void Interact()
    {
        _collider.enabled = false;
        particles.Stop();
        arkDisplay.SetActive(true);
        FogController.instance.AddFog();
        _enableViolin.Interacted();
    }
}
