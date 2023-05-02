using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class EyeBlinkEfect : MonoBehaviour
{
    [SerializeField]
    private GameObject Blink;
    private GameObject Pj;
    [SerializeField]
    private Animator anim;
    public bool blink = false;
    private bool isPlaying = false;
    public UnityEvent blinking;
    public UnityEvent noBlinking;
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
        //StartCoroutine(stopBlink());
    }
    public void BlinkExit()
    {
        anim.SetTrigger("isBlinking");
    }
    IEnumerator stopBlink ()
    {
        yield return new WaitForSeconds(transitionTime);
        videoPlayer.Play();
        isPlaying = true;
        Invoke("BlinkExit", (float)videoPlayer.length - transitionTime);
        yield return new WaitForSeconds(2f);
        videoPlayer.Stop();
        noBlinking.Invoke();
        
        isPlaying = false;
        
    }

    public void TestBlink()
    {
        videoPlayer.Play();
        isPlaying = true;
        Invoke("StopTestBlink", 2.0f - transitionTime);
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


}
