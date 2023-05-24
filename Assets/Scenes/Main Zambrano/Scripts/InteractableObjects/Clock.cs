using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour, IInteractable
{
    [SerializeField] private BoxCollider _collider;
    [SerializeField] private ParticleSystem particles;

    public void Interact()
    {
        _collider.enabled = false;
        particles.Stop();
        MemoriesController.instance.PlayMemory(2);
    }
}
