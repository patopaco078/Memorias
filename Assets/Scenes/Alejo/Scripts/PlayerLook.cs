using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{

    private static PlayerLook _instance; // Para poder acceder desde otro lado junto lo del awake
    public static PlayerLook Instance { get { return _instance; } }

    [SerializeField] float mouseSensitivity = 300f;

    [SerializeField] Transform playerBody;

    private float xAxisClamp;
    private bool canMove = true;


    private void Awake() {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        LockCursor();
        xAxisClamp = 0.0f;
    }


    private void LockCursor() {
        Cursor.lockState = CursorLockMode.Locked;
       
    }

    private void Update() {
        CameraRotation();
    }

    private void CameraRotation() {

        if (canMove) //Daniel J, para poder bloquear la rotacion 
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xAxisClamp += mouseY;

            if (xAxisClamp > 90.0f)
            {
                xAxisClamp = 90.0f;
                mouseY = 0.0f;
                ClampXAxisRotationToValue(270.0f);
            }
            else if (xAxisClamp < -90.0f)
            {
                xAxisClamp = -90.0f;
                mouseY = 0.0f;
                ClampXAxisRotationToValue(90.0f);
            }

            transform.Rotate(Vector3.left * mouseY);
            playerBody.Rotate(Vector3.up * mouseX);
        }

       
    }

    private void ClampXAxisRotationToValue(float value) {
        Vector3 eulerRotation = transform.eulerAngles;
        eulerRotation.x = value;
        transform.eulerAngles = eulerRotation;
    }

    public void CantMoveCamera()
    {
        canMove = false;
    }

    public void MoveAgain()
    {
        canMove = true;
    }
    public void Desbloqueamouse()
    {
        Cursor.lockState = CursorLockMode.None;
        
        Cursor.visible = true;
    }
    public void BloquearMouse()
    {
        LockCursor();
        Cursor.visible = false;

    }
}