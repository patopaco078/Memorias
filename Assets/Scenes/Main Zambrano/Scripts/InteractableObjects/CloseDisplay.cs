using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDisplay : MonoBehaviour
{
    
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            gameObject.SetActive(false);
            PlayerMovementZambrano.instance.enabled = true;
            CameraMovementZambrano.instance.ignoreMousePos = false;
        }
    }
}
