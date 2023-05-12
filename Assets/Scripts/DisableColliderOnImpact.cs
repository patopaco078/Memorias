using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//by Nico

public class DisableColliderOnImpact : MonoBehaviour
{
    [SerializeField] private Collider collider3D;

    private void Start()
    {
        collider3D = GetComponent<Collider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") // Verifica si el jugador impactó el objeto
        {
            Debug.Log("Trampa!");
            collider3D.enabled = false; // Desactiva el collider del objeto
        }
    }
}
