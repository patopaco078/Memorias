using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//camargo

[RequireComponent(typeof(Checking))]
[RequireComponent(typeof(AudioSource))]
public class MusicController : MonoBehaviour
{
    private Checking checkerCode;

    [SerializeField] MousePositionArco MPA;
    [SerializeField] ClipMusic[] moments;
    int ActualClip = 0;
    private AudioSource aS;
    [SerializeField] private bool isPlaying = false;
    private bool canUse = false;

    [SerializeField] bool isLeft;
    bool a = true;

    public bool CanUse { get => canUse;}
    public ClipMusic[] Moments { get => moments; set => moments = value; }

    private void Start()
    {
        aS = gameObject.GetComponent<AudioSource>();
        checkerCode = gameObject.GetComponent<Checking>();
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
        int i = 0;
        if (MPA.Speed != 0)
            isPlaying = true;
        else
            isPlaying = false;
        
        if (isPlaying)
        {
            if (isLeft)
            {
                //checkerCode.CheckMusic(moments[i].DistanceOfArco, )
            }
        }

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

    private void startClip()
    {
        aS.Play();
    }

    private void stopClip()
    {
        aS.Pause();
    }

    public void NowCanUseViolin()
    {
        canUse = true;
    }
}
