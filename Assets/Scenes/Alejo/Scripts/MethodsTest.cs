using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MethodsTest : MonoBehaviour
{
    [SerializeField] private UIInstructionsController instructions;
    private void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Player"))return;
        instructions.ShowInstructions();
    }
}
