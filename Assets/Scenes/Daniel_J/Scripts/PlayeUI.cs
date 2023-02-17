using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayeUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI promptText;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void UpdateText(string promptMesaage)
    {
        promptText.text = promptMesaage;
    }
}
