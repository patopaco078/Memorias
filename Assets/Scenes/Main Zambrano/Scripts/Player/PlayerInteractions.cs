using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    [SerializeField]private Camera cam;

    [SerializeField] private GameObject interactionDisplayObject;

    [SerializeField] private TextMeshProUGUI interactionText;

    [SerializeField] private AudioSource interactionSound;

    [SerializeField] private PlayerMovementZambrano playerMovement;
    [SerializeField] private CameraMovementZambrano cameraMovement;
    
    // Start is called before the first frame update

    
    void Update()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit,2f,LayerMask.GetMask("Interactable")))
        {
            interactionDisplayObject.SetActive(true);
            interactionText.text = hit.collider.GetComponent<InteractableDisplayText>().displayText;

            if (Input.GetMouseButtonDown(0))
            {
                playerMovement.enabled = false;
                cameraMovement.ignoreMousePos = true;
                hit.collider.GetComponent<IInteractable>().Interact();
                interactionSound.Play();
            }
        }
        else
        {
            interactionDisplayObject.SetActive(false);
        }
    }

    
}
