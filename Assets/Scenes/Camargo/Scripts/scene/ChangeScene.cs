using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] int NumberScene;
    [SerializeField] bool finishGame = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (finishGame)
            {
                Application.Quit();
            }
            else
            {
                SceneManager.LoadScene(NumberScene);
            }
        }
    }
}
