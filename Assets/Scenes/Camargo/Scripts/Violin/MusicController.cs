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
    [SerializeField] private bool canUse = false;

    [SerializeField] bool isLeft;
    [SerializeField] bool NowIsLeft = true;
    float TimeToCorrectTiming = 0f;
    bool TryPLayMusic = true;
    

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
            Debug.Log("Level 1");
            if (checkerCode.CheckMusic(moments[ActualClip].DistanceN, PlayerArcoPosition(), aS.time, moments[ActualClip].FinishTime) || CorrectTiming())
            {
                Debug.Log("Level 2");
                if (TryPLayMusic)
                {
                    Debug.Log("Level 3");
                    aS.Play();
                    TryPLayMusic = false;
                }
                if(CorrectTiming() && checkerCode.IsGoodTiming)
                {
                    Debug.Log("Level 4");
                    ChangeDirection();
                }
            }
            else
            {
                Debug.Log("se cansela");
                checkerCode.ResetCheckOutClip();
                aS.Stop();

                TryPLayMusic = true;
            }

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
            TimeToCorrectTiming = 0f;
        }
        else
        {
            return false;
        }
    }

    private float PlayerArcoPosition()
    {
        return MPA.ActualPosition.position.x - MPA.StartPosition.x;
    }

    public void ChangeDirection()
    {
        bool momentaryA = true;
        if (NowIsLeft && momentaryA)
        {
            NowIsLeft = false;
            momentaryA = false;
        }
        if (!NowIsLeft && momentaryA)
        {
            NowIsLeft = true;
            momentaryA = false;
        }
    }
}
