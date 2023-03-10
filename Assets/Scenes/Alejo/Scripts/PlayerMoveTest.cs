using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Archivo Original de Bello, editado por: Alejo López para agregar Bobbing Walking.

public class PlayerMoveTest : MonoBehaviour
{

    [Header("Movement")]
    public float moveSpeed;
    public float groundDrag;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;
    
    //Add by Alejo:
    [Header("Bobbing Walking"), SerializeField] Animator walkingAnim; //Para las animaciones de caminar
    AudioSource _audioSource; // Audio pasos
    private ushort controlPlayAudio = 0;
    [SerializeField] private float timeToPlayAudio = 1.5f;

    // Start is called before the first frame update
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }


    // Update is called once per frame
    private void Update()
    {
        //Suelo Check °_°
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        MyInput();
        SpeedControl();

        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        //Calcular la direccion del moviemiento
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        
        //****Se activan y desactivan las animaciones de Caminar**** Add by Alejo
        if(horizontalInput != 0 || verticalInput!=0) {
            walkingAnim.SetBool("isMoving", true);
            if (controlPlayAudio == 0)
            {
                _audioSource.Play();
                controlPlayAudio++;
            }
        }
        else {
            walkingAnim.SetBool("isMoving", false);
            _audioSource.Pause();
            controlPlayAudio = 0;
        }
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        
        //limitador de velocidad si se necesita
        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

}
