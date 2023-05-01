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

    //recordatorio de notas
    [SerializeField] private bool[] rememberedNotes = new bool[4];

    public bool CanUse { get => canUse;}
    public ClipMusic[] Moments { get => moments; set => moments = value; }
    public bool NowIsLeft1 { get => NowIsLeft;}

    private void Start()
    {
        aS = gameObject.GetComponent<AudioSource>();
        checkerCode = gameObject.GetComponent<Checking>();
    }

    private void Update()
    {
        if (canUse && !checkerCode.IsGoodTiming && MPA.IsTouchViolin)
        {
            detectSide();
            PlayingClip();
        }
        if (checkerCode.IsGoodTiming)
            aS.Stop();
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
            if (checkerCode.CheckMusic((moments[ActualClip].DistanceN / moments[ActualClip].FinishTime), MPA.Speed, aS.time, moments[ActualClip].FinishTime) || CorrectTiming())
            {
                if (TryPLayMusic)
                {
                    aS.Play();
                    TryPLayMusic = false;
                }
                if(CorrectTiming() && checkerCode.IsGoodTiming)
                {
                    checkerCode.ResetCheckOutClip();
                    ActualClip++;
                    ChangeDirection();
                }
            }
            if (checkerCode.CheckMusic((moments[ActualClip].DistanceN / moments[ActualClip].FinishTime), (MPA.Speed * -1), aS.time, moments[ActualClip].FinishTime) || CorrectTiming())
            {
                if (TryPLayMusic)
                {
                    aS.Play();
                    TryPLayMusic = false;
                }
                if (CorrectTiming() && checkerCode.IsGoodTiming)
                {
                    checkerCode.ResetCheckOutClip();
                    ActualClip++;
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
        checkerCode.ResetCheckOutClip();
    }

    public void NowCanUseViolin()
    {
        canUse = true;
    }
    public void NowCantUseViolin()
    {
        canUse = false;
    }

    private bool CorrectTiming()
    {
        TimeToCorrectTiming += Time.deltaTime;
        if(TimeToCorrectTiming < 0.1f)
        {
            TimeToCorrectTiming = 0f;
            return true;
        }
        stopClip();
        return false;
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

    public void RememberANote()
    {
        if (rememberedNotes[0])
        {
            rememberedNotes[1] = true;
            return;
        }
        if (rememberedNotes[1])
        {
            rememberedNotes[2] = true;
            return;
        }
        if (rememberedNotes[2])
        {
            rememberedNotes[3] = true;
            return;
        }
    }

    public void ForgetAllNote()
    {
        rememberedNotes[0] = false;
        rememberedNotes[1] = false;
        rememberedNotes[2] = false;
        rememberedNotes[3] = false;
    }

    public void RememberAllNote()
    {
        rememberedNotes[0] = true;
        rememberedNotes[1] = true;
        rememberedNotes[2] = true;
        rememberedNotes[3] = true;
    }

}
