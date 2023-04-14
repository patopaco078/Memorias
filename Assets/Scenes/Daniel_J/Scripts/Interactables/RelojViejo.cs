using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RelojViejo : Interactable
{

    [SerializeField] UnityEvent WhenActive = new UnityEvent();

    protected override void Interact()
    {
        WhenActive.Invoke();
        Debug.Log("Reloj");
    }
}
