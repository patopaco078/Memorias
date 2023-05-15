using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Codigo Hecho por ALEJO el 8/05/2023

public class OpenDoorWithKeyBoard : MonoBehaviour
{
    /* Este Script va en un objeto vacío con un Trigger, su función es detectar al jugador y controlar las animaciones
        de la puerta */
        [Header("Door Animator"),SerializeField] private Animator doorAnimator;
        [Header("Door Collider"), SerializeField] private Collider doorCollider;
        [SerializeField] private GameObject openDoorInstructions;
        private AudioSource m_audioSouerce;
        private Collider myTriggerCollider; /*El collider del doorSystem es desactivado en el Awake para evitar que detecte al jugador y abrá la puerta */
        private bool playerReadIntrucctions = false;
        private void Awake()
        {
            m_audioSouerce = GetComponent<AudioSource>();
            myTriggerCollider = GetComponent<Collider>();
            myTriggerCollider.enabled = false;
            openDoorInstructions.SetActive(false);
        }
        
        public void UnlockDoor()
        //Se desactiva el collider de la puerta para evitar bugs en las físicas
        //Se Activa el trigger el del doorController para que detecte al jugador y abra o cierre la puerta
        {
            myTriggerCollider.enabled = true;
            doorCollider.enabled = false;
        }
        private void OnTriggerStay(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            if (!playerReadIntrucctions) openDoorInstructions.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E))
            {
                OpenDoor(); 
                openDoorInstructions.SetActive(false);
                playerReadIntrucctions = true;
            }
        }
    
        private void OnTriggerExit(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            CloseDoor();
            openDoorInstructions.SetActive(false);
            playerReadIntrucctions = false;
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
        
        //Se llama BlockDoor para que la puerta no pueda ser traspasada por el jugador y tampoco se abra.
        public void BlockDoor()
        {
            CloseDoor();
            myTriggerCollider.enabled = false;
            doorCollider.enabled = true; 
        }
}
