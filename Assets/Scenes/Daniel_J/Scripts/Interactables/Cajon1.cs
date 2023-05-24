using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cajon1 : MonoBehaviour, IInteractable
{
    [SerializeField]private BoxCollider _collider;
    [SerializeField] private Animator anim;

    public void Interact()
    {
        anim.SetTrigger("AbrirCajon1");
        _collider.enabled = false;
        PlayerMovementZambrano.instance.enabled = true;
        CameraMovementZambrano.instance.ignoreMousePos = false;
    }
}
