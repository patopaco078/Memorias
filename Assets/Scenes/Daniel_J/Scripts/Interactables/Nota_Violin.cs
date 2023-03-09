using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Nota_Violin : Interactable
{
    [SerializeField]
    private Image violinBoton;

    [SerializeField] UnityEvent WhenActive = new UnityEvent();

    protected override void Interact()
    {
       violinBoton.gameObject.SetActive(true);
       Player_moverse.Instance.PlayViolin();
        WhenActive.Invoke();
    }
}
