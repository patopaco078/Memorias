using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
//camargo

public class ActivateViolín : MonoBehaviour
{
    [SerializeField] MusicController MusicController;
    [SerializeField] GameObject violin;
    bool isActivate = false;
    bool a =true;

    [SerializeField] UnityEvent OnActivate;
    [SerializeField] UnityEvent OnDesactivate;

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
                    ActivateViolinInGame();
                }
                if (isActivate && a)
                {
                    DesactivateViolinInGame();
                }
            }

            if (!a)
            {
                a = true;
            }
        }
    }

    public void ActivateViolinInGame()
    {
        OnActivate.Invoke();
        violin.SetActive(true);
        isActivate = true;
        a = false;
    }

    public void DesactivateViolinInGame()
    {
        OnDesactivate.Invoke();
        violin.SetActive(false);
        isActivate = false;
        a = false;
    }
}
