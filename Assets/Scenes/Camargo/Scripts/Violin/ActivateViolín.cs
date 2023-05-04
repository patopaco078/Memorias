using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
//camargo

public class ActivateViolín : MonoBehaviour
{
    [SerializeField] MusicController MusicController;
    [SerializeField] GameObject violinObject;
    bool isViolinActive = false;

    [SerializeField] UnityEvent OnActivate;
    [SerializeField] UnityEvent OnDesactivate;

    [Header("- TESTING -")]
    [SerializeField] bool debugMode = false;

    // Referencia al componentes del violin

    private void Start()
    {
        violinObject.SetActive(false);
    }

    private void Update()
    {
        //desde acá se puede activar o desactivar el viólin en pantalla

        if (debugMode)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (!isViolinActive)
                {
                    ActivateViolinInGame();
                }
                else
                {
                    DesactivateViolinInGame();
                   
                }
            }
        }
        else
        {
            if (MusicController.CanUse)
            {
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    if (!isViolinActive)
                    {
                        ActivateViolinInGame();
                    }
                    else
                    {
                        DesactivateViolinInGame();
                    }
                }
            }
        }
    }

    public void ActivateViolinInGame()
    {
        OnActivate.Invoke();
        violinObject.SetActive(true);
        isViolinActive = true;

        // Inicialización lógica del violin
        violinObject.GetComponentInChildren<MusicController>().EnableLogic();
        violinObject.GetComponentInChildren<Checking>().AppearUIViolin();
    }

    public void DesactivateViolinInGame()
    {
        OnDesactivate.Invoke();
        violinObject.SetActive(false);
        isViolinActive = false;

        // Terminación lógica del violin
        violinObject.GetComponentInChildren<MusicController>().DisableLogic();
        violinObject.GetComponentInChildren<Checking>().DisappearUIViolin();
    }
}
