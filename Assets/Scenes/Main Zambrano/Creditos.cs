using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Creditos : MonoBehaviour
{
    public void ResetGame()
    {
        SceneManager.LoadScene("MenuInicial");
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
