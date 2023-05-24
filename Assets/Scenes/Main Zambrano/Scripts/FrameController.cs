using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class FrameController : MonoBehaviour, IInteractable
{
    [SerializeField] private MeshRenderer frameRendere;

    [SerializeField] private Material frameMaterials;

    [SerializeField] private Material hideMaterial;

    [SerializeField] private ParticleSystem particles;

    [SerializeField] private BoxCollider _collider;

    [SerializeField] private Light _light;

    public Action OnActivedFrame;

    private bool activedFrame;
    
    [SerializeField] private FrameTextController displayTextController;

    [SerializeField] private int frameId;
    void Start()
    {
        frameMaterials = frameRendere.material;
        frameRendere.material = hideMaterial;
        MakeFlake();
    }

    public void MakeFlake()
    {
        StartCoroutine(Flake());
    }

    IEnumerator Flake()
    {
        while (!activedFrame)
        {
            _light.intensity = 0;
            yield return new WaitForSeconds(.3f);
            _light.intensity = 2.4f;
            yield return new WaitForSeconds(1);
            _light.intensity = 0;
            yield return new WaitForSeconds(.3f);
            _light.intensity = 2.4f;
        }
    }
    

    IEnumerator ShowFrame()
    {
        OnActivedFrame?.Invoke();
        particles.Play();
        yield return new WaitForSeconds(2f);
        frameRendere.material = frameMaterials;
        _collider.enabled = false;
        displayTextController.ShowText(frameId);
        Destroy(this);
    }

    public void Interact()
    {
        StartCoroutine(ShowFrame());
        activedFrame = true;
        _light.intensity = 2.4f;
    }
}
