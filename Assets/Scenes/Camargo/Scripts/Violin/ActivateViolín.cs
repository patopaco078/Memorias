using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//camargo

public class ActivateViolín : MonoBehaviour
{
    [SerializeField] MusicController MusicController;
    [SerializeField] GameObject violin;
    bool isActivate = false;
    [SerializeField] bool a =true;

    private void Start()
    {
        violin.SetActive(false);
    }

    private void Update()
    {
        //desde acá se puede activar o desactivar el viólin en pantalla
        if (MusicController.CanUse)
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
}
