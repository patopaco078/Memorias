using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    }

    void Update()
    {
        MyInput();
        Mover();
        gravedad();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    public void Mover()
    {
        Vector3 forwardSpeed = transform.forward * Input.GetAxis("Vertical") * movementSpeed;
        Vector3 rightSpeed = transform.right * Input.GetAxis("Horizontal") * movementSpeed;
        speed = forwardSpeed + rightSpeed;

        //****Se activan y desactivan las animaciones de Caminar**** Add by Alejo
        /*
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
        }*/
    }

    void gravedad()
    {
        if (charController.isGrounded)
        {
            vSpeed = 0;
        }
        vSpeed += gravity;
        speed.y = vSpeed;
        charController.Move(speed * Time.deltaTime);
    }
}
