using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tocador : MonoBehaviour, IInteractable
{
    [SerializeField]private BoxCollider _collider;
    
    private bool animationPlayed;
    public void Interact()
    {
        if (animationPlayed)
        {
            //abrir cajon
            _collider.enabled = false;
        }
        else
        {
            BlinkController.Instance.Blink();
            MemoriesController.instance.PlayMemory(4);
        }
        
        
    }
}
