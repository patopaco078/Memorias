using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    [SerializeField] MousePositionArco MPA;
    [SerializeField] ClipMusic[] Moments;
    int ActualClip = 0;
    private AudioSource aS;
    [SerializeField] private bool isPlaying = false;

    [SerializeField] bool isLeft;
    bool a = true;

    private void Start()
    {
        aS = gameObject.GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(MPA.Speed > 0)
        {
            isLeft = true;
        }
        if (MPA.Speed < 0)
        {
            isLeft = false;
        }
        PlayingClip();
        
    }

    private void PlayingClip()
    {
        if (MPA.Speed != 0)
            isPlaying = true;
        else
            isPlaying = false;
        /*
        if (isPlaying)
        {
            if (isLeft)
            {

            }
        }*/

        if (isPlaying)
        {
            if (a)
            {
                aS.Play();
                Debug.Log("a");
                a = false;
            }
        }

        else
        {
            Debug.Log("b");
            aS.Pause();
            a = true;
        }
    }
}
