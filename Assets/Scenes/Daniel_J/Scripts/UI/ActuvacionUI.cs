using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ActuvacionUI : MonoBehaviour
{
    [SerializeField]
    private Image objetivoActual;
    [SerializeField]
    private float segundos;
    [SerializeField]
    private UnityEvent disableImage;
    // Start is called before the first frame update
    public void ActivarObjetivo()
    {
        objetivoActual.gameObject.SetActive(true);

        StartCoroutine(ActivarObj());
        

    }

    IEnumerator ActivarObj()
    {
        yield return new WaitForSeconds(segundos);
        disableImage.Invoke();

        objetivoActual.gameObject.SetActive(false);
    }

}
