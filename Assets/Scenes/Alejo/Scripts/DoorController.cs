using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//By: Alejo López

public class DoorController : MonoBehaviour
{
    /* Este Script va en un objeto vacío con un Trigger, su función es detectar al jugador y controlar las animaciones
    de la puerta */
    [Header("Door Animator"),SerializeField] private Animator doorAnimator;
    [Header("Door Collider"), SerializeField] private Collider doorCollider;
    private AudioSource m_audioSouerce;
    private Collider myTriggerCollider; /*El collider del doorSystem es desactivado en el Awake para evitar que 
    detecte al jugador y abrá la puerta */

    private void Awake()
    {
        m_audioSouerce = GetComponent<AudioSource>();
        myTriggerCollider = GetComponent<Collider>();
        myTriggerCollider.enabled = false;
    }

    public void UnlockDoor()
    //Se desactiva el collider de la puerta para evitar bugs en las físicas
    //Se Activa el trigger el del doorController para que detecte al jugador y abra o cierre la puerta
    {
        myTriggerCollider.enabled = true;
        doorCollider.enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        OpenDoor();
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        CloseDoor();
    }

    public void OpenDoor()
    {
        doorAnimator.SetBool("isClosed", true);
        m_audioSouerce.Play();
    }

    public void CloseDoor()
    {
        doorAnimator.SetBool("isClosed", false);
    }
}
