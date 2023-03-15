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
    bool NowIsLeft = true;
    float TimeToCorrectTiming = 0f;

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
        if(isLeft == NowIsLeft)
        {
            //if(checkerCode.CheckMusic(moments[ActualClip],))
        }
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

    private bool CorrectTiming()
    {
        TimeToCorrectTiming += Time.deltaTime;
        if(TimeToCorrectTiming < checkerCode.RanckError)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
