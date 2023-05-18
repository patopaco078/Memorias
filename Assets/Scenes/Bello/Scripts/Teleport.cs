using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private GameObject pj;
    // Start is called before the first frame update
   

    private void OnTriggerEnter(Collider other)
    {
        pj.transform.position = target.transform.position;
    }
}
