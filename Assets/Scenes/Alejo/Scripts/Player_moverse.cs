using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_moverse : MonoBehaviour
{
    private static Player_moverse _instance; // Para poder acceder desde otro lado justo los del awake
    public static Player_moverse Instance { get { return _instance; } }

    public float movementSpeed;
    public float movimientonormal;
    


    private bool canPlayviolin = false;
    public bool isPlaying = false;

    float horizontalInput;
    float verticalInput;
    //Add by Alejo:
    [Header("Bobbing Walking"), SerializeField] Animator walkingAnim; //Para las animaciones de caminar
    [SerializeField] AudioSource _audioSource; // Audio pasos
    private ushort controlPlayAudio = 0;
    [SerializeField] private ControlInputs inputState;

    float gravity = -10;  
    float vSpeed = 0;
    CharacterController charController; 
    Vector3 speed;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        charController = GetComponent<CharacterController>();
        movementSpeed = movimientonormal;
        _audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        MyInput();
        if(inputState.state == 0) Mover();
        if(inputState.state == 1) InvertMove();
        gravedad();
        ActivateViolin();
        WalkingAnimation();
        
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
    }

    void InvertMove()
    {
        Vector3 forwardSpeed = transform.forward * Input.GetAxis("Vertical") * movementSpeed * -1;
        Vector3 rightSpeed = transform.right * Input.GetAxis("Horizontal") * movementSpeed * -1;
        speed = forwardSpeed + rightSpeed;
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

    public void StopMove()
    {
        
        movementSpeed = 0;

    }
    public void MoveAgain()
    {
        movementSpeed = movimientonormal;
    }

   public void PlayViolin()
   {
        canPlayviolin= true;
   }
    private void ActivateViolin()
    {
        if (Input.GetKeyDown(KeyCode.Q)&& canPlayviolin && !isPlaying)
        {
            Debug.Log("Toco violin");
            isPlaying = true;
            StopMove();
            PlayerLook.Instance.CantMoveCamera();
            PlayerLook.Instance.Desbloqueamouse();
            PlayerLook.Instance.mouseview = true;

        }
        else if (Input.GetKeyDown(KeyCode.Q) && isPlaying)
        {
            Debug.Log("Ya no toco violin");
            isPlaying = false;
            MoveAgain();
            PlayerLook.Instance.MoveAgain();
            PlayerLook.Instance.Desbloqueamouse();
            PlayerLook.Instance.mouseview = false;
        }

    }
    private void StopViolin()
    {
        if (Input.GetKeyDown(KeyCode.Q) && isPlaying)
        {
            isPlaying = false;
            MoveAgain();
            PlayerLook.Instance.MoveAgain();
        }

             
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
