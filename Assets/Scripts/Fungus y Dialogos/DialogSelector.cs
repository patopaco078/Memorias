using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.Events;
//By Nico Villa


public class DialogSelector: MonoBehaviour
{
    //Este script sirve para llamar los bloques de dialogo del fungus con los unity events
    [SerializeField] private UnityEvent doThisWhenActivate;
    public Flowchart flowTest;
    private string mensaje;

    public void DialogBlocksActivation(string blockName)
    {
        flowTest.ExecuteBlock(blockName);
        mensaje = blockName;
        doThisWhenActivate.Invoke();
    }
    public void TestMethod() {
        Debug.Log(mensaje);
    }
}
