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
        StartCoroutine(stopBlink());
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
        Invoke("BlinkExit", (float)videoPlayer.length + 0.5f - transitionTime);
        yield return new WaitForSeconds((float)videoPlayer.length);
        videoPlayer.Stop();
        noBlinking.Invoke();
        isPlaying = false;
        
    }

    //


}
