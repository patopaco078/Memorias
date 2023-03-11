using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeBlinkEfect : MonoBehaviour
{
    [SerializeField]
    private GameObject Blink;
    [SerializeField]
    private Animator anim;
    public bool blink = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = Blink.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            anim.SetTrigger("isBlinking");
        }
    }
}
