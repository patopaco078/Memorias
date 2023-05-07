using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class EyeBlinkEfect : MonoBehaviour
{
    [SerializeField]
    private GameObject Blink;
    private GameObject Pj;
    [SerializeField]
    private Animator anim;
    [SerializeField] VideoPlayer videoPlayer1;
    [SerializeField] VideoPlayer videoPlayer2;
    [SerializeField] VideoPlayer videoPlayer3;
    public bool blink = false;
    private bool isPlaying = false;
    public UnityEvent blinking;
    public UnityEvent noBlinking;
    public UnityEvent finishanim1;
    public UnityEvent finishanim2;
    public UnityEvent finishanim3;
    [SerializeField]
    private VideoPlayer videoPlayer;
    //private VideoPlayer[] videoPlayerList = new VideoPlayer[4];

    public float transitionTime = 1.3f;
    // Start is called before the first frame update
    void Start()
    {
        anim = Blink.GetComponent<Animator>();
    }
     void update()
    {
        if (Input.GetKeyDown(KeyCode.P) && isPlaying)
        {
            isPlaying = false;
            
        }

    }
    // Update is called once per frame
    public void camBlink()
    {
       blinking.Invoke();
       anim.SetTrigger("isBlinking");
        
    }
    public void BlinkExit()
    {
        anim.SetTrigger("isBlinking");
    }
   

    public void TestBlink()
    {
        videoPlayer.Play();
        isPlaying = true;
        float time = (float)videoPlayer.length;
        Invoke("StopTestBlink", time - transitionTime);
    }

    private void StopTestBlink()
    {
        anim.SetTrigger("OutBlink");
    }   

    public void Stoop()
    {
        videoPlayer.Stop();
        noBlinking.Invoke();
        isPlaying = false;
    }
    // Estos valores son los reales (float)videoPlayer.length (float)videoPlayer.length los que puse fue por que el video era muy largo
    //Animacion 1
    public void Anim1()
    {
        anim.SetTrigger("isBlinkingAnim1");
    }
    public void PlayAnim1()
    {
        videoPlayer1.Play();
        isPlaying= true;
        float time = (float)videoPlayer1.length;
        Invoke("StopAnim1", time - transitionTime);
    }

    public void StopAnim1()
    {
        anim.SetTrigger("OutBlinkingAnim1");
    }

    public void StopPlayer1()
    {
        videoPlayer1.Stop();
        isPlaying= false;
        finishanim1.Invoke();
    }
    //Animacion 2
    public void Anim2()
    {
        anim.SetTrigger("isBlinkingAnim2");
    }
    public void PlayAnim2()
    {
        videoPlayer2.Play();
        isPlaying = true;
        float time = (float)videoPlayer2.length;
        Invoke("StopAnim2", time - transitionTime);
    }

    public void StopAnim2()
    {
        anim.SetTrigger("OutBlinkingAnim2");
    }

    public void StopPlayer2()
    {
        videoPlayer2.Stop();
        isPlaying = false;
        finishanim1.Invoke();
        finishanim2.Invoke();
    }
    //Animacion 3
    public void Anim3()
    {
        anim.SetTrigger("isBlinkingAnim3");
    }
    public void PlayAnim3()
    {
        videoPlayer3.Play();
        isPlaying = true;
        float time = (float)videoPlayer3.length;
        Invoke("StopAnim3", time - transitionTime);
    }

    public void StopAnim3()
    {
        anim.SetTrigger("OutBlinkingAnim3");
    }

    public void StopPlayer3()
    {
        videoPlayer3.Stop();
        isPlaying = false;
        finishanim1.Invoke();
    }
}
