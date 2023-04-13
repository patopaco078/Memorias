using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//By: Alejo López
//El script es un componente del objeto original que va a ser cambiado
//Se debe llamar el método ChangeModel desde cualquier otro Script o evento para activarlo.

public class ModelChanger : MonoBehaviour
{
   [SerializeField] private GameObject secondObject; //El objeto por el cual se va a cambiar el original
   private Vector3 elementPos;

   private void Awake()
   {
      elementPos = transform.position;
      secondObject.transform.position = elementPos;
      secondObject.SetActive(false);
   }

   /*private void Update()
   {
      if (Input.GetKeyDown(KeyCode.W))
      {
         ChangeModel();
      }
   }*/

   public void ChangeModel()
   {
      gameObject.SetActive(false);
      secondObject.SetActive(true);
   }
}
