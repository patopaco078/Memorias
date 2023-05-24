using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Violin : MonoBehaviour, IInteractable
{
    [SerializeField] private ParticleSystem particles;
    [SerializeField] private GameObject violinParent;

    public void Interact()
    {
        particles.Stop();
        FogController.instance.haveViolin = true;
        violinParent.SetActive(false);
        BlinkController.Instance.Blink();
        MemoriesController.instance.PlayMemory(0);
    }
}
