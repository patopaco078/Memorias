using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxLight : MonoBehaviour
{
    [SerializeField] Habitacion2LightController habitacion2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            habitacion2.TurnOn();
    }
}
