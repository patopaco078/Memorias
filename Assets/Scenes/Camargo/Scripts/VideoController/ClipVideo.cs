using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
//camargo

public class ClipVideo : MonoBehaviour
{
    public Transform Position;
    public float TimeAnimation;

    public UnityEvent CallFuntions;

    public int Pesta�a;

    private void Start()
    {
        Position = transform;
    }
}
