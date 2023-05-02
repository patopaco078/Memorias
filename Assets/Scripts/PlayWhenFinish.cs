using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayWhenFinish : MonoBehaviour
{
    [SerializeField] UnityEvent WhenFinishAudio;
    [SerializeField] AudioSource Audio;
    private bool a;
    private void Update()
    {
        if (Audio.isPlaying)
        {
            a = true;
        }
        if(a && !Audio.isPlaying)
        {
            WhenFinishAudio.Invoke();
        }
    }
}
