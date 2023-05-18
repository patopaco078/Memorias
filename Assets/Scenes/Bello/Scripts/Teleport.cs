using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Teleport : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private GameObject pj;
    [SerializeField]
    private UnityEvent seTeletrasporta;
   

    private void OnTriggerEnter(Collider other)
    {
        seTeletrasporta.Invoke();
        pj.transform.position = target.transform.position;
        
    }
}
