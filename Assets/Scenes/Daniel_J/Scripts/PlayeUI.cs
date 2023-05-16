using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayeUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI promptText;

    [SerializeField] 
    private GameObject backGroundText;

    // Start is called before the first frame update
  
    public void UpdateText(string promptMesaage)
    {
        promptText.text = promptMesaage;

        backGroundText.SetActive(promptMesaage.Length != 0);
    }
}
