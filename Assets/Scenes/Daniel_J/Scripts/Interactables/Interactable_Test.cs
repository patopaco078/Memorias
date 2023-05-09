using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_Test : Interactable
{ 

    protected override void Interact()
    {
        Debug.Log("Se interactuo con " + gameObject.name);
    }

}
