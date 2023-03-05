using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//By Alejo
//El script es para simular la función que controla el tomar o dejar la hoja

public class SheetTest : MonoBehaviour
{
    [SerializeField] private SheetManager sheet;
    public ushort counter = 0;

    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        if (Input.GetKeyDown(KeyCode.E) && counter == 0)
        {
            counter = 1;
        }
        
        //Al dejar la hoja: Llamar la función DeactivateSheet
        if (Input.GetKeyDown(KeyCode.E) && counter == 1)
        {
            sheet.DeactivateSheet();
        }


    }
}
