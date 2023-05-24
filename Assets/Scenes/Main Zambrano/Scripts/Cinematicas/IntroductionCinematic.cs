using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class IntroductionCinematic : MonoBehaviour
{
    [FormerlySerializedAs("audio")] [SerializeField] private AudioSource audioClara1;
    [SerializeField] private AudioSource audioMecedora;

    [SerializeField] private Animator playerAnimator;

    [SerializeField] private PlayerMovementZambrano playerMovement;

    [SerializeField] private CameraMovementZambrano cameraControl;

    [SerializeField] private PlayerInteractions playerInteractions;

    [SerializeField] private ParticleSystem postItParticles;

    [SerializeField] private BoxCollider mecedoraCollider;

    [SerializeField] private GameObject pointer;
    
    // Start is called before the first frame update
    void Start()
    {
        pointer.SetActive(false);
        mecedoraCollider.enabled = false;
        audioMecedora.Play();
        cameraControl.ignoreMousePos = true;
        playerInteractions.enabled = false;
        playerMovement.enabled = false;
        playerMovement.rb.useGravity = false;
        playerAnimator.Play("Mecedora");
        StartCoroutine(InitialCinematic());
    }

    IEnumerator InitialCinematic()
    {
        yield return new WaitForSeconds(2f);
        audioClara1.Play();
        cameraControl.ignoreMousePos = false;
        pointer.SetActive(true);
        yield return new WaitForSeconds(18f);
        playerAnimator.SetTrigger("Sit");
        audioMecedora.Stop();
        playerInteractions.enabled = true;
        postItParticles.Play();
    }

    public void EndCinematic()
    {
        PostItsDisplay.instance.ClosePostIt();
        cameraControl.ignoreMousePos = false;
        playerAnimator.Play("WakeUp");
        playerMovement.enabled = true;
        Invoke("EnableMecedoraCollider", 5f);
    }

    public void EnableMecedoraCollider()
    {
        mecedoraCollider.enabled = true;
    }
}
