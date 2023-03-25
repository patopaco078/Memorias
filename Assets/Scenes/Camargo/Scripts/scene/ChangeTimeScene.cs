using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeTimeScene : MonoBehaviour
{
    [SerializeField] float TimeInThisScene;
    [SerializeField] int NumberScene;
    private float TimeNow;

    private void Update()
    {
        if(TimeNow >= TimeInThisScene)
        {
            SceneManager.LoadScene(NumberScene);
        }
        TimeNow += Time.deltaTime;
    }
}
