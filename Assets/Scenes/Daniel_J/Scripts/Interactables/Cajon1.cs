using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cajon1 : Interactable
{

    [SerializeField] private Animator anim;
    private bool isOpen = false;
    // Start is called before the first frame update
    protected override void Interact()
    {
        if (!isOpen)
        {
            anim.SetTrigger("AbrirCajon1");
            isOpen = true;
        }
        else
        {
            anim.SetTrigger("CerrarCajon1");
            isOpen = false;
        }

    }
}
