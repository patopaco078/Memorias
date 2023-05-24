using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PrincipalFrame : MonoBehaviour, IInteractable
{
    [SerializeField] private MeshRenderer frameRendere;

    [SerializeField] private Material frameMaterials;

    [SerializeField] private Material hideMaterial;

    [SerializeField] private ParticleSystem particles;
    
    [SerializeField] private List<FrameController> frames;

    [SerializeField] private List<Light> ligths;

    [SerializeField] private BoxCollider _collider;


    [SerializeField] private ParticleSystem llamativeParticles;
    private int activedFramesCounter;

    private bool activedFrame;

    [SerializeField] private FrameTextController displayTextController;

    [SerializeField] private AudioSource _audio;

    [SerializeField] private PuertaSala puerta;
    // Start is called before the first frame update
    void Start()
    {
        frameMaterials = frameRendere.material;
        frameRendere.material = hideMaterial;
        foreach (var frame in frames)
        {
            frame.OnActivedFrame += UpdateActivedFrames;
        }
    }

    private void UpdateActivedFrames()
    {
        activedFramesCounter++;

        if (activedFramesCounter >= 5)
        {
            llamativeParticles.Play();
            foreach (var light in ligths)
            {
                light.gameObject.SetActive(true);
            }

            StartCoroutine(Flake());
        }
    }
    
    IEnumerator Flake()
    {
        while (!activedFrame)
        {
            foreach (var light in ligths)
            {
                light.intensity = 0;
            }
            yield return new WaitForSeconds(.3f);
            foreach (var light in ligths)
            {
                light.intensity = 2.4f;
            }
            yield return new WaitForSeconds(1);
            foreach (var light in ligths)
            {
                light.intensity = 0;
            }
            yield return new WaitForSeconds(.3f);
            foreach (var light in ligths)
            {
                light.intensity = 2.4f;
            }
        }
    }
    
    public void Interact()
    {

        if (activedFramesCounter <= 4)
        {
            displayTextController.ShowText(5);
        }
        else
        {
            foreach (var light in ligths)
            {
                light.intensity = 2.4f;
                llamativeParticles.Stop();
            }

            StartCoroutine(ShowFrame());
        }
    }
    
    IEnumerator ShowFrame()
    {
        puerta.OpenDoor();
        particles.Play();
        yield return new WaitForSeconds(2f);
        frameRendere.material = frameMaterials;
        _collider.enabled = false;
        _audio.Play();

        yield return new WaitForSeconds(13f);
        BlinkController.Instance.Blink();
        MemoriesController.instance.PlayMemory(1);
        Destroy(this);
    }

}
