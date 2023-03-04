using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//By: Alejo López

public class Player_moverse : MonoBehaviour
{
    public float movementSpeed;
    public float movimientonormal;

    float horizontalInput;
    float verticalInput;
    //Add by Alejo:
    [Header("Bobbing Walking"), SerializeField] Animator walkingAnim; //Para las animaciones de caminar
    AudioSource _audioSource; // Audio pasos
    private ushort controlPlayAudio = 0;
    [SerializeField] private float timeToPlayAudio = 1.5f;

    float gravity = -10;  
    float vSpeed = 0;
    CharacterController charController; 
    Vector3 speed;

    private void Awake()
    {
        charController = GetComponent<CharacterController>();
        movementSpeed = movimientonormal;
        _audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        MyInput();
        Mover();
        Gravedad();
        WalkingAnimation();
        
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    public void Mover()
    {
        Vector3 forwardSpeed = transform.forward * verticalInput * movementSpeed;
        Vector3 rightSpeed = transform.right * horizontalInput * movementSpeed;
        speed = forwardSpeed + rightSpeed;
    }

    void Gravedad()
    {
        if (charController.isGrounded)
        {
            vSpeed = 0;
        }
        vSpeed += gravity;
        speed.y = vSpeed;
        charController.Move(speed * Time.deltaTime);
    }

    void WalkingAnimation() //****Se activan y desactivan las animaciones de Caminar**** Add by Alejo
    { 
        
       if (horizontalInput != 0 || verticalInput != 0)
       {
           walkingAnim.SetBool("isMoving", true);
           if (controlPlayAudio == 0)
           {
               _audioSource.Play();
               controlPlayAudio++;
           }
       }
       else
       {
           walkingAnim.SetBool("isMoving", false);
           _audioSource.Pause();
           controlPlayAudio = 0;
       }
    }
}
