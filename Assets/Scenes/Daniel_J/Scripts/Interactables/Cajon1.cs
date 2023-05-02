using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cajon1 : Interactable
{

    [SerializeField] private Animator anim;
    private bool isOpen = false;
    // Start is called before the first frame update
    private void Start()
    {
        promptMessage = "Abrir(Pulsa E)";
    }
    protected override void Interact()
    {
        if (!isOpen)
        {
            anim.SetTrigger("AbrirCajon1");
            promptMessage = "Cerrar(Pulsa E)";
            isOpen = true;
        }
        else
        {
            promptMessage = "Abrir(Pulsa E)";
            anim.SetTrigger("CerrarCajon1");
            isOpen = false;
        }

    }
}
