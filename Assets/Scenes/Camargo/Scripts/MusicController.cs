using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    [SerializeField] ClipMusic[] Moments;
    private AudioSource aS;

    private void Start()
    {
        aS = gameObject.GetComponent<AudioSource>();
    }

    private void Update()
    {
        
    }
}
