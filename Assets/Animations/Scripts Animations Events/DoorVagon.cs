using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorVagon : MonoBehaviour, IInteractable
{
    private Animator anim;
    [SerializeField] Animator otherDoorObject;
    [SerializeField] AudioSource audioDoor;

    [SerializeField] private BoxCollider doorCollider;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void StartOpenDoor()
    {
        anim.SetTrigger("openDoor");
        otherDoorObject.SetTrigger("openDoor");
        audioDoor.Play();
    }
    

    public void Interact()
    {
        StartOpenDoor();
        doorCollider.enabled = false;
        PlayerMovementZambrano.instance.enabled = true;
        CameraMovementZambrano.instance.ignoreMousePos = false;
    }
}
