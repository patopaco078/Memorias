using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cajon : Interactable
{
    private Animator anim;
    private bool isOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        anim= GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
