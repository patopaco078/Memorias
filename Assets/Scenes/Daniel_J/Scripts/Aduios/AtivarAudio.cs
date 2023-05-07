using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivarAudio : MonoBehaviour
{
    [SerializeField] private AudioSource audio;
    private int contador =1;
    private void OnTriggerEnter(Collider other)
    {
        if (contador > 0)
        {
            audio.Play();
            contador--;
        }
       
    }
}
