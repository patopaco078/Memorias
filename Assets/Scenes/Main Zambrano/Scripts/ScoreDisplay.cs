using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    
    
    [SerializeField] private Sprite score1;
    [SerializeField] private Sprite score2;
    [SerializeField] private Sprite score3;
    [SerializeField] private Sprite score4;

    [SerializeField] private GameObject display;
    [SerializeField] private Image imageDisplay;


    public void ShowScore(int id)
    {
        display.SetActive(true);
        switch (id)
        {
            case 0:
                imageDisplay.sprite = score1;
                break;
            case 1:
                imageDisplay.sprite = score2;
                break;
            case 2:
                imageDisplay.sprite = score3;
                break;
            case 3:
                imageDisplay.sprite = score4;
                break;
        }
    }

    public void HideScore()
    {
        display.SetActive(false);
    }


}
