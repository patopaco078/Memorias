using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text1;
    [SerializeField] private TextMeshProUGUI text2;
    [SerializeField] private TextMeshProUGUI text3;
    [SerializeField] private TextMeshProUGUI text4;

    [SerializeField] private Image fadePanel;
    void Start()
    {
        LeanTween.value(text1.gameObject, 0, 1, 2).setOnUpdate((float val) =>
        {
            Color c = text1.color;
            c.a = val;
            text1.color = c;
        }).setOnComplete(ShowSecondText);
    }

    private void ShowSecondText()
    {
        LeanTween.value(text2.gameObject, 0, 1, 2).setOnUpdate((float val) =>
        {
            Color c = text2.color;
            c.a = val;
            text2.color = c;
        }).setOnComplete(ShowThirtText);
    }

    private void ShowThirtText()
    {
        LeanTween.value(text3.gameObject, 0, 1, 2).setOnUpdate((float val) =>
        {
            Color c = text3.color;
            c.a = val;
            text3.color = c;
        }).setOnComplete(ShowFourtText);
    }

    private void ShowFourtText()
    {
        LeanTween.value(text4.gameObject, 0, 1, 2).setOnUpdate((float val) =>
        {
            Color c = text4.color;
            c.a = val;
            text4.color = c;
        }).setOnComplete(SetChangeScene);
    }

    void SetChangeScene()
    {
        StartCoroutine(ChangeScene());
    }

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(2);
        LeanTween.value(fadePanel.gameObject, 0, 1, 2).setOnUpdate((float val) =>
        {
            Color c = fadePanel.color;
            c.a = val;
            fadePanel.color = c;
        });
        
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("Main Zambrano");
    }

}
