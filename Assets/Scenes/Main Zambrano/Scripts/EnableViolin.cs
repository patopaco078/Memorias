using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableViolin : MonoBehaviour
{
    public int interactedObjects;

    [SerializeField] private ParticleSystem particles;
    [SerializeField] private BoxCollider _collider;
    
    public void Interacted()
    {
        interactedObjects++;
        if (interactedObjects >= 2)
        {
            particles.Play();
            _collider.enabled = true;
        }
    }
    
    
}
