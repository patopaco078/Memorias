using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartituraFinal : MonoBehaviour, IInteractable
{
    [SerializeField] private BoxCollider _collider;
    [SerializeField] private AudioSource _claraVoice;
    [SerializeField] private GameObject _claraNoteUi;
    [SerializeField] private AudioSource _ancianoCancion;
    [SerializeField] private AudioSource _claraRespuesta1;

    [SerializeField] private AudioSource violinMusic;
    [SerializeField] private AudioSource ClaraLast;


    [SerializeField] private ArkMovementZambrano violin;

    public void Interact()
    {
        _collider.enabled = false;
        PlayerMovementZambrano.instance.enabled = false;
        StartCoroutine(cinematic());
    }

    IEnumerator cinematic()
    {
        _claraNoteUi.SetActive(true);
        yield return new WaitForSeconds(1f);
        _claraVoice.Play();
        yield return new WaitForSeconds(15f);
        _claraNoteUi.SetActive(false);
        yield return new WaitForSeconds(2f);
        _ancianoCancion.Play();
        yield return new WaitForSeconds(4f);
        _claraRespuesta1.Play();
        yield return new WaitForSeconds(2f);
        violin.endGame = true;
        violin.ActiveViolin();
    }
}
