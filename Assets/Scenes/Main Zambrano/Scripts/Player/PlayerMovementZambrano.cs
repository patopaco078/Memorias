using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementZambrano : MonoBehaviour
{
    public static PlayerMovementZambrano instance;
    
    [SerializeField] private float movementSpeed;
    [SerializeField] private Animator animator;

    public Rigidbody rb;

    private bool collision;

    private Vector3 dir;

    public bool invertControls;

    [SerializeField] private ArkMovementZambrano violin;

    [SerializeField] private GameObject PauseMenu;
    private bool pauseMenuActive;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

        Cursor.visible = false;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        
        if (dir.magnitude == 0)
        {
            rb.velocity = Vector3.zero;
        }

        if (Input.GetKeyDown(KeyCode.Q) && FogController.instance.canPlay)
        {
            violin.ActiveViolin();
        }
        
    }

    private void FixedUpdate()
    {
        Vector3 moveDirection = Camera.main.transform.forward * dir.z + Camera.main.transform.right * dir.x;
        if (invertControls)
        {
            rb.velocity = new Vector3(-moveDirection.normalized.x * movementSpeed, 0, -moveDirection.normalized.z * movementSpeed);
        }
        else
        {
            rb.velocity = new Vector3(moveDirection.normalized.x * movementSpeed, 0, moveDirection.normalized.z * movementSpeed);
        }


        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatVel.magnitude > movementSpeed)
        {
            Vector3 limitVel = flatVel.normalized * movementSpeed;
            rb.velocity = limitVel;
        }
    }


    public void DisableAnimator()
    {
        rb.useGravity = true;
        animator.enabled = false;
    }

    public void ActiveAnimator()
    {
        animator.enabled = true;
    }
}
