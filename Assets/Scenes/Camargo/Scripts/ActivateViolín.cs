using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateViolín : MonoBehaviour
{
    [SerializeField] GameObject violin;
    bool isActivate = false;
    [SerializeField] bool a =true;

    private void Start()
    {
        violin.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (!isActivate && a)
            {
                Debug.Log("a");
                violin.SetActive(true);
                isActivate = true;
                a = false;
            }
            if (isActivate && a)
            {
                violin.SetActive(false);
                isActivate = false;
                a = false;
            }
        }

        if (!a)
        {
            a = true;
        }
    }
}
