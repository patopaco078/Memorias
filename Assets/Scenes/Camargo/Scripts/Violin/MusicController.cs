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

    public int actualClip = 0;
    int targetClip = 1;

    private AudioSource aS;
    [SerializeField] private bool isPlaying = false;
    [SerializeField] private bool canUse = false;

    [SerializeField] bool isSwipingAndTouchingLeft;
    [SerializeField] bool playingDirectionIsLeft = true;
    float TimeToCorrectTiming = 0f;
    bool TryPLayMusic = true;

    //recordatorio de notas
    [SerializeField] private bool[] rememberedNotes = new bool[4];

    public bool CanUse { get => canUse;}
    public ClipMusic[] Moments { get => moments; set => moments = value; }
    public bool NowIsLeft { get => playingDirectionIsLeft;}

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
        if (MPA.MovementDir == MovementDirection.Left)
        {
            isSwipingAndTouchingLeft = true;
        }
        else
        {
            isSwipingAndTouchingLeft = false;
        }
    }

    private void PlayingClip()
    {
        if(isSwipingAndTouchingLeft == playingDirectionIsLeft)
        {
            if (checkerCode.CheckMusic((moments[actualClip].DistanceN / moments[actualClip].FinishTime), MPA.Speed, aS.time, moments[actualClip].FinishTime) || CorrectTiming())
            {
                if (TryPLayMusic)
                {
                    //aS.Play();
                    TryPLayMusic = false;
                }
                if(CorrectTiming() && checkerCode.IsGoodTiming)
                {
                    Debug.LogWarning("Success?");
                    checkerCode.ResetCheckOutClip();

                    actualClip++;
                    checkerCode.onSuccesfullyPlayedNote.Invoke();

                    ChangeDirection();

                    if (actualClip == targetClip)
                    {
                        RememberANote();
                        checkerCode.onSecuenceSuccesfullyPlayed.Invoke();
                        canUse = false;

                        GetComponentInParent<ActivateViolín>().DesactivateViolinInGame();
                    }
                }
            }
            else
            {
                Debug.Log("se cansela");
                checkerCode.ResetCheckOutClip();
                aS.Stop();

                actualClip = 0;
                playingDirectionIsLeft = true;

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
        print("?");
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
        if (playingDirectionIsLeft && momentaryA)
        {
            playingDirectionIsLeft = false;
            momentaryA = false;
        }
        if (!playingDirectionIsLeft && momentaryA)
        {
            playingDirectionIsLeft = true;
            momentaryA = false;
        }
    }

    public void RememberANote()
    {
        if (rememberedNotes[2])
        {
            rememberedNotes[3] = true;
            targetClip = 4;
            return;
        }

        if (rememberedNotes[1])
        {
            rememberedNotes[2] = true;
            targetClip = 3;
            return;
        }

        if (rememberedNotes[0])
        {
            rememberedNotes[1] = true;
            targetClip = 2;
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

    public void ResetPlayingSequence()
    {
        actualClip = 0;
        playingDirectionIsLeft = true;
    }
    
    #region"Activacion y desactivacion del violin"

    public void EnableLogic()
    {
        isPlaying = true;
        isSwipingAndTouchingLeft = false;
        playingDirectionIsLeft = true;
        actualClip = 0;
    }

    public void DisableLogic()
    {
        isPlaying = false;
        isSwipingAndTouchingLeft = false;
        playingDirectionIsLeft = false;
        actualClip = 0;
    }
    #endregion
}
