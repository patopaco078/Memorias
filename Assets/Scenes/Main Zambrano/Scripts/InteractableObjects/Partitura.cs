using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Partitura : MonoBehaviour, IInteractable
{
    [SerializeField] private BoxCollider _collider;
    [SerializeField] private AudioSource _audio;


    [SerializeField] private GameObject Atril;
    [SerializeField] private GameObject Clara;

    [SerializeField] private ArkMovementZambrano violin;
    public void Interact()
    {
        _collider.enabled = false;
        PlayerMovementZambrano.instance.enabled = false;
        CameraMovementZambrano.instance.ignoreMousePos = true;
        BlinkController.Instance.Blink();
        MemoriesController.instance.PlayMemory(3);
        PlayerMovementZambrano.instance.invertControls = true;
        
        FogController.instance.AddFog();
        FogController.instance.AddFog();
        FogController.instance.AddFog();

        StartCoroutine(PlayCinematic());
    }

    IEnumerator PlayCinematic()
    {
        FogController.instance.canDicipate = false;
        Atril.SetActive(true);
        Clara.SetActive(true);
        yield return new WaitForSeconds(30f);
        _audio.Play();
        PlayerMovementZambrano.instance.enabled = true;
        CameraMovementZambrano.instance.ignoreMousePos = false;
        yield return new WaitForSeconds(15f);
        PlayerMovementZambrano.instance.gameObject.transform.position = new Vector3(-10.66f, 1.037f, 11.304f);
        violin.EndViolinGame();
        FogController.instance.canDicipate = true;
        yield return new WaitForSeconds(1);
        FogController.instance.ReduceFog();
        yield return new WaitForSeconds(1);
        FogController.instance.ReduceFog();
        yield return new WaitForSeconds(1);
        FogController.instance.ReduceFog();
        PlayerMovementZambrano.instance.enabled = false;
    }
}
