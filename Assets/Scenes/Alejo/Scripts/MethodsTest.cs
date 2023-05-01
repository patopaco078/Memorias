using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MethodsTest : MonoBehaviour
{
    [SerializeField] private Teleporter _teleporterPlayer;
    private void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Player"))return;
        _teleporterPlayer.ChangeOfPlace();
    }
}
