using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
    public void Playgame()
    {
        SceneManager.LoadScene("Cinematica");

    }
    public void Exitgame()
    {
        Debug.Log("Salir...");
        Application.Quit();
    }
}
