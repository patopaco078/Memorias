using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PostItsDisplay : MonoBehaviour
{
    public static PostItsDisplay instance;
    
    [SerializeField] private GameObject postItsPanel;

    [SerializeField] private Image postItSprite;

    [SerializeField] private List<Sprite> postIts = new List<Sprite>();

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    public void ShowPostIt(int postItId)
    {
        postItsPanel.SetActive(true);
        postItSprite.sprite = postIts[postItId];
    }

    public void ClosePostIt()
    {
        postItsPanel.SetActive(false);
    }

}
