using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MusicController))]
public class ActualizateClipMusic : MonoBehaviour
{
    [SerializeField] float LongDistance = 3;
    [SerializeField] float ShortDistance = 1;

    private MusicController MC;
    private void Awake()
    {
        MC = gameObject.GetComponent<MusicController>();
    }

    private void Start()
    {
        for(int i = 0; i < MC.Moments.Length; i++)
        {
            if (MC.Moments[i].DistanceOfArco == ClipMusic.Distance.DistanceLong)
                MC.Moments[i].DistanceN = LongDistance;
            if (MC.Moments[i].DistanceOfArco == ClipMusic.Distance.DistanceShort)
                MC.Moments[i].DistanceN = ShortDistance;

            Debug.Log(MC.Moments[i].DistanceN);
        }
    }
}
