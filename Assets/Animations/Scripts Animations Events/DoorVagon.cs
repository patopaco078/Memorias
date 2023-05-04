using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorVagon : MonoBehaviour
{
    private Animator anim;
    [SerializeField] Animator otherDoorObject;
    [SerializeField] AudioSource audioDoor;
    [SerializeField] NieblaController NC;

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

    public void ActiveDarkNiebla()
    {
        NC.ActivateNiebla();
    }
}
