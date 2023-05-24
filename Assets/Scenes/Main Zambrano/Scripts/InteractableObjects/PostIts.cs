using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostIts : MonoBehaviour, IInteractable
{
    [SerializeField] private ParticleSystem particles;
    [SerializeField] private BoxCollider _collider;
    public void Interact()
    {
        PostItsDisplay.instance.ShowPostIt(0);
        if(particles != null)
            particles.Stop();
        _collider.enabled = false;
        CameraMovementZambrano.instance.ignoreMousePos = true;
        FogController.instance.AddFog();
    }
}
