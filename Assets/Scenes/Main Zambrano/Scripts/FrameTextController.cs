using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FrameTextController : MonoBehaviour
{
    [SerializeField] private string alceText;
    [SerializeField] private string roadText;
    [SerializeField] private string trailText;
    [SerializeField] private string violin1Text;
    [SerializeField] private string violin2Text;

    [SerializeField] private string memoryFailText;

    [SerializeField] private GameObject textBackGround;
    [SerializeField] private TextMeshProUGUI framText;

    public void ShowText(int id)
    {
        switch (id)
        {
            case 0:
                framText.text = alceText;
                break;
            case 1:
                framText.text = roadText;
                break;
            case 2:
                framText.text = trailText;
                break;
            case 3:
                framText.text = violin1Text;
                break;
            case 4:
                framText.text = violin2Text;
                break;
            case 5:
                framText.text = memoryFailText;
                break;
        }
        
        textBackGround.SetActive(true);
    }
}
