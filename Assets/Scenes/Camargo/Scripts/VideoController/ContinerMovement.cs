using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
//camargo

public class ContinerMovement : MonoBehaviour
{
    [SerializeField] Transform PlayerTransform;
    private bool ISCallPosition = true;
    [SerializeField] private bool PlayOnAwake;
    [SerializeField] ClipVideo[] TimeLine;
    private bool IsPlay = false;
    private float TimeAnimationCamera = 0f;
    private int i = 0;

    
    private void Start()
    {
        if (PlayOnAwake)
            IsPlay = true;
    }

    private void Update()
    {
        if (IsPlay)
        {
            if (i < TimeLine.Length)
                OnAnimationIsPLay();
        }
    }

    public void PlayAnimation()
    {
        IsPlay = true;
    }

    private void OnAnimationIsPLay()
    {
        switch (TimeLine[i].Pestaña)
        {
            case 0:
                if (TimeAnimationCamera < TimeLine[i].TimeAnimation)
                {
                    TimeAnimationCamera += Time.deltaTime;
                    
                }
                if (ISCallPosition)
                {
                    PlayerTransform.DOMove(TimeLine[i].Position.position, TimeLine[i].TimeAnimation);
                    PlayerTransform.DORotate(TimeLine[i].Position.rotation.eulerAngles, TimeLine[i].TimeAnimation);
                    ISCallPosition = false;
                }

                if (TimeAnimationCamera >= TimeLine[i].TimeAnimation)
                {
                    i++;
                    ISCallPosition = false;
                }
                break;
            case 1:
                TimeLine[i].CallFuntions.Invoke();
                i++;
                break;
        }
    }
}
