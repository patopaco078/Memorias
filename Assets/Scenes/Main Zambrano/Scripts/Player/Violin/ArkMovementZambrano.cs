using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ArkMovementZambrano : MonoBehaviour
{
    [SerializeField] private GameObject violin;
    
    private Vector3 previousPosition;

    private float speed;

    private float progress;

    private float arkMovementMultiplier;

    [SerializeField] private GameObject Ark;
    
    public float maxValue = 2000f;

    private float porcentaje;

    [SerializeField] private Slider slider;
    [SerializeField] private Slider progressBar;


    [SerializeField] private AudioSource violinMusic;
    [SerializeField] private AudioSource violinGameMusic;
    
    [SerializeField] private GameObject violinUI;

    private bool violinActive;

    private int amountOfViolinActivedTimes;


    [SerializeField] private ScoreDisplay ScoreDisplay;

    [SerializeField] private Animator anim;


    [SerializeField] private GameObject violinIcon;

    [SerializeField] private AudioSource ClaraLast;

    [SerializeField] private GameObject blackPanel;

    public bool endGame;

    public void ActiveViolin()
    {
        violinActive = true;
        violin.SetActive(true);
        violinUI.SetActive(true);
        amountOfViolinActivedTimes++;
        violinIcon.SetActive(false);
        violinGameMusic.Play();
        FogController.instance.canPlay = false;
        PlayerMovementZambrano.instance.enabled = false;
        CameraMovementZambrano.instance.ignoreMousePos = true;
    }
    
    // Update is called once per frame
    void Update()
    {
        if(!violinActive)
            return;

        Vector3 currentPosition = Input.mousePosition;

        float distance = Vector3.Distance(currentPosition, previousPosition);

        speed = distance / Time.deltaTime;

        previousPosition = currentPosition;

        porcentaje = (speed / maxValue);

        Mathf.Clamp(porcentaje, 0f, 1f);

        
        
        slider.value = Mathf.Lerp(slider.value, porcentaje/100, 0.01f);
        
        
        if (porcentaje >= 6 && porcentaje <= 12)
        {
            progress += 0.1f;
            Vector3 currentPos = Ark.transform.localPosition;
            currentPos.x = arkMovementMultiplier * 0.01f;
            anim.SetBool("Tocando", true);
        }
        else
        {
            progress -= 0.001f;
            anim.SetBool("Tocando", false);
        }

        progress = Mathf.Clamp(progress, 0, 100);

        progressBar.value = progress / 100;

        if(progress == 100)
            EndViolinGame();

    }

    public void EndViolinGame()
    {
        StartCoroutine(RemoveFog());
    }

    IEnumerator RemoveFog()
    {
        violinGameMusic.Stop();
        violinMusic.Play();
        violinUI.SetActive(false);
        ScoreDisplay.ShowScore(amountOfViolinActivedTimes-1);
        violin.SetActive(false);
        yield return new WaitForSeconds(5f);
        ScoreDisplay.HideScore();
        FogController.instance.ReduceFog();
        FogController.instance.ReduceFog();
        FogController.instance.ReduceFog();
        FogController.instance.ReduceFog();
        violinActive = false;
        progress = 0;
        PlayerMovementZambrano.instance.enabled = true;
        CameraMovementZambrano.instance.ignoreMousePos = false;

        if (endGame)
            StartCoroutine(EndGame());
    }

    IEnumerator EndGame()
    {
        BlinkController.Instance.Blink();
        yield return new WaitForSeconds(3f);
        ClaraLast.Play();
        blackPanel.SetActive(true);
        yield return new WaitForSeconds(6f);
        SceneManager.LoadScene("Creditos");
    }
}
