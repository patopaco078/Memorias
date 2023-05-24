using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CajonAnimatic : MonoBehaviour
{
    [SerializeField] private BoxCollider _collider;

    
    private void OnTriggerEnter(Collider other)
    {
        _collider.enabled = false;
        PlayerMovementZambrano.instance.enabled = false;
        CameraMovementZambrano.instance.ignoreMousePos = true;
        BlinkController.Instance.Blink();
        MemoriesController.instance.PlayMemory(4);
    }
}
