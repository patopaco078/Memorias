using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PruebaDeEventos : MonoBehaviour
{
    [SerializeField] UnityEvent OnPlayerTouchTheTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            OnPlayerTouchTheTrigger.Invoke();
        }
    }
}
