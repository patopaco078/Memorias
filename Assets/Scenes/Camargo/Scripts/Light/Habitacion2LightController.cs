using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Habitacion2LightController : MonoBehaviour
{
    [SerializeField] Light_Pared[] LPs;
    [SerializeField] Light_Pared FatherLP;
    [SerializeField] float BaseTimeTurnOn;
    [SerializeField] float FatherTimeTurnOn;

    private bool isRun = false;
    private float ActualTimeRuning = 0f;
    private int i = 0;
    private bool finishBaseLight = false;

    private void Update()
    {
        if (isRun)
        {
            if (!finishBaseLight)
            {
                if (ActualTimeRuning < BaseTimeTurnOn)
                {
                    ActualTimeRuning += Time.deltaTime;
                }
                else
                {
                    LPs[i].TurnOnLights();
                    i++;
                    ActualTimeRuning = 0f;
                    if (i >= LPs.Length)
                        finishBaseLight = true;
                }
            }
            else
            {
                if (ActualTimeRuning < FatherTimeTurnOn)
                {
                    ActualTimeRuning += Time.deltaTime;
                }
                else
                {
                    FatherLP.TurnOnLights();
                }
            }
        }
    }

    public void TurnOn()
    {
        isRun = true;
    }
}
