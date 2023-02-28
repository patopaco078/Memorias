using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//By: Alejo López

public class KeyDoor : MonoBehaviour
{
    //NOTA: Este Script representa el evento o condición que desbloquea la puerta
    [SerializeField] private DoorController doorController;
    private void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Player")) return;
        doorController.UnlockDoor(); //El evento o condición debe llamar a este método.
        Destroy(gameObject);
    }
}
