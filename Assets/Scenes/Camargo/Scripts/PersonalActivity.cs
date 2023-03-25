using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PersonalActivity : MonoBehaviour
{
    //si se activa con un boton Funciona acá
    [SerializeField] bool haveButton = false;
    [SerializeField] KeyCode ButtonToActive;

    //Funciones que se llaman
    [SerializeField] UnityEvent WhenStart;
    [SerializeField] UnityEvent WhenIsActive;

    private bool isActive = false;
    private void Update()
    {
        if (haveButton)
        {
            if (Input.GetKeyDown(ButtonToActive))
            {
                if (isActive)
                {
                    callEvents();
                }
            }
        }
        if (!haveButton)
        {
            if (isActive)
            {
                callEvents();
            }
        }
    }

    // Esta funcion se llama cuando se quiere hacer inicio a la Actividad
    public void ActiveActivity()
    {
        WhenStart.Invoke();
        isActive = true;
    }

    // Esta funcion se llama cuando se termina la Actividad
    private void callEvents()
    {
        WhenIsActive.Invoke();
        isActive = false;
    }
}
