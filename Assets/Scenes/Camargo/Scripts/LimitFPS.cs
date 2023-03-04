using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitFPS : MonoBehaviour
{
    [SerializeField] float FPS = 30;

    private void Start()
    {
        Application.targetFrameRate = 45;
    }
}
