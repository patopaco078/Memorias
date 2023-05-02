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
    public bool blink = false;
    private bool isPlaying = false;
    public UnityEvent blinking;
    public UnityEvent noBlinking;
    public UnityEvent finishanim1;
    [SerializeField]
    private VideoPlayer videoPlayer;
    //private VideoPlayer[] videoPlayerList = new VideoPlayer[4];

    private float transitionTime = 1.3f;
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
}
