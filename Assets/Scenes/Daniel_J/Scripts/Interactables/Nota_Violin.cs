using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Nota_Violin : Interactable
{
    [SerializeField]
    private Image violinBoton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected override void Interact()
    {
       violinBoton.gameObject.SetActive(true);
       Player_moverse.Instance.PlayViolin();
    }
}
