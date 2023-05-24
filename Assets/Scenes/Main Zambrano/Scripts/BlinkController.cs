using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkController : MonoBehaviour
{
    public static BlinkController Instance;
    
    
    [SerializeField] private Animator anim;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void Blink()
    {
        anim.Play("blink");
    }
}
