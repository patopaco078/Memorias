using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//camargo

public class MusicController : MonoBehaviour
{
    [SerializeField] MousePositionArco MPA;
    [SerializeField] ClipMusic[] Moments;
    int ActualClip = 0;
    private AudioSource aS;
    [SerializeField] private bool isPlaying = false;
    private bool canUse = false;

    [SerializeField] bool isLeft;
    bool a = true;

    public bool CanUse { get => canUse;}

    private void Start()
    {
        aS = gameObject.GetComponent<AudioSource>();

        for(int i = 0; i < Moments.Length; i++)
        {
            Debug.Log(Moments[i].Speed);
        }
    }

    private void Update()
    {
        if (canUse)
        {
            detectSide();
            PlayingClip();
        }
    }

    private void detectSide()
    {
        if (MPA.Speed > 0)
        {
            isLeft = true;
        }
        if (MPA.Speed < 0)
        {
            isLeft = false;
        }
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
                //Debug.Log("a");
                a = false;
            }
        }

        else
        {
            //Debug.Log("b");
            aS.Pause();
            a = true;
        }

        //-------------------------NEW CODE-------------------------


    }

    public void NowCanUseViolin()
    {
        canUse = true;
    }
}
