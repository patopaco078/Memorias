using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EyeBlinkEfect : MonoBehaviour
{
    [SerializeField]
    private GameObject Blink;
    [SerializeField]
    private Animator anim;
    public bool blink = false;
    public UnityEvent blinking;
    // Start is called before the first frame update
    void Start()
    {
        anim = Blink.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (blink == true)
        {
            blinking.Invoke();
            anim.SetTrigger("isBlinking");
        }
    }


}
