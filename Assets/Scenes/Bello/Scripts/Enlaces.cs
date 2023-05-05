using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enlaces : MonoBehaviour
{
    
    public void enlaceBoton(string link)
    {
        Application.OpenURL(link);
    }
    
}
