using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Nota_Intecartuable : Interactable
{
    public delegate void MiDelegado();
   

    private bool isInspecting = false;
    private Vector3 originalPosition;
    private Quaternion originalRotation;
    public float moveSpeed = 3.0f;
    private float rotationSpeed = 10.0f;
    public float initialDistance=1;
    private MeshCollider mesh;
    private bool isRotating = false;

    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<MeshCollider>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0)) // 0 indica el clic izquierdo del mouse
        {
            isRotating = true;
        }

        if (Input.GetMouseButtonUp(0)) // el clic se levanto
        {
            isRotating = false;
        }


        if (isInspecting)
        {
            PlayerLook.Instance.CantMoveCamera();
            Player_moverse.Instance.StopMove();

            // Move object towards camera
            float distance = Mathf.Lerp(Vector3.Distance(transform.position, Camera.main.transform.position), 0, Time.deltaTime * moveSpeed);
            transform.position = Camera.main.transform.position + Camera.main.transform.forward * (initialDistance );
            // Rotate
            if (isRotating) // Si se ha hecho clic en el botón del mouse
            {
                float rotateHorizontal = Input.GetAxis("Mouse X") * rotationSpeed;
                float rotateVertical = Input.GetAxis("Mouse Y") * rotationSpeed;

                transform.Rotate(Vector3.up, -rotateHorizontal, Space.World);
                transform.Rotate(Vector3.right, rotateVertical, Space.World);
            }
            mesh.enabled = false;

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                
                isInspecting = false;
                transform.position = originalPosition;
                transform.rotation = originalRotation;
                mesh.enabled = true;

                PlayerLook.Instance.MoveAgain();
                Player_moverse.Instance.MoveAgain();
            }
        }



    }
    protected override void Interact()
    {
        Debug.Log("Se interactuo con " + gameObject.name);

        isInspecting = true;       
        originalPosition = transform.position;
        originalRotation = transform.rotation;
        
    }
}
