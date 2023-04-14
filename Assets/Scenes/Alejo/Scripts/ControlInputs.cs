using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//By: Alejo López
public class ControlInputs : MonoBehaviour
{
  //Crear un GO con este script
  //Al player_moverse agregar el ControlInputs en el inspector
  
  public ushort state = 0;

  public void InvertMovement()
  {
    state = 1;
  }

  public void NormalizeMovement()
  {
    state = 0;
  }
}
