using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  UnityEngine.UI;
//By: Alejo Lopez
//El evento o acción que haga aparecer las instrucciones debe llamar al método Showintructions()

public class UIInstructionsController : MonoBehaviour
{
    [SerializeField] private Image instructions;
    bool isVisible = false;
    
    void Update()
    {
        HideInstructions();
    }

    void HideInstructions()
    {
        if (!isVisible || !Input.GetKeyDown(KeyCode.E)) return;
        instructions.gameObject.SetActive(false);
        isVisible = false;
    }

    public void ShowInstructions()
    {
        instructions.gameObject.SetActive(true);
        isVisible = true;
    }
}
