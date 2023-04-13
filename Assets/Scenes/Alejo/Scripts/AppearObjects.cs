using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearObjects : MonoBehaviour
{
   private Renderer objectRenderer;
   
   private void OnTriggerEnter(Collider other)
   {
      if (other.CompareTag("AppearFurniture"))
      {
         objectRenderer = other.GetComponent<Renderer>();
         objectRenderer.enabled = true;
      }
   }
}
