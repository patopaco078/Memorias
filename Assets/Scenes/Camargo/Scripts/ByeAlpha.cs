using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class ByeAlpha : MonoBehaviour
{
    private PersonalActivity PA;

    private void Start()
    {
        PA = GetComponent<PersonalActivity>();
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            PA.ActiveActivity();
    }

    public void chageToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
