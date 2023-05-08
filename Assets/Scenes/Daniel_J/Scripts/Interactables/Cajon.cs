using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cajon : Interactable  //Daniel Jaramillo Script de la interaccion para abrir cajones
{
    private Animator anim;
    private bool isOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        anim= GetComponent<Animator>();
    }
    

    protected override void Interact()
    {
       if(!isOpen )
       {
            anim.SetTrigger("Open");
            isOpen = true;
       }
       else
       {
            anim.SetTrigger("Close");
            isOpen = false;
       }
       
    }
}
