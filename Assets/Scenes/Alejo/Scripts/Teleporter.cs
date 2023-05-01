using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//By: Alejo López
public class Teleporter : MonoBehaviour
{
    [SerializeField] private Transform referencePos;
    [SerializeField] private Transform playerPos;
    
    public void ChangeOfPlace()
    {
        playerPos.position = referencePos.position;
    }
    
}
