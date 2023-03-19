using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Events;
//camargo

[System.Serializable]
public class ClipMusic
{
    public enum Distance { DistanceLong, DistanceShort };

    [SerializeField] Distance distanceOfArco;
    [SerializeField] float finishTime;
    [SerializeField] float ErrorRange;

    
    private float distanceN;
    public float DistanceN { get => distanceN; set => distanceN = value; }
    public Distance DistanceOfArco { get => distanceOfArco; }
    public float FinishTime { get => finishTime; }
}