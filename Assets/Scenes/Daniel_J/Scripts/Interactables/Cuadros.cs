using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Cuadros : Interactable
{

    [SerializeField] UnityEvent WhenActive = new UnityEvent();

    protected override void Interact()
    {
        WhenActive.Invoke();
        Debug.Log("La legolisa");
    }

}
