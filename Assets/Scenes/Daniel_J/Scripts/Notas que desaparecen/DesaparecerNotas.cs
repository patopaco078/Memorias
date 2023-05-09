using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DesaparecerNotas : Interactable
{
    public delegate void MiDelegado();


    public bool isInspecting = false;
    public float distanceEntre;
    private Vector3 originalPosition;
    private Quaternion originalRotation;
    public float moveSpeed = 3.0f;
    private float rotationSpeed = 10.0f;
    public float initialDistance = 1;
   
    private BoxCollider box;
    private float originalPositionY;
    private int count = 1;

    [SerializeField]
    private UnityEvent activarObjetivo;

    // Start is called before the first frame update
    void Start()
    {
       
        box = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {      
        if (isInspecting)
        {
            PlayerLook.Instance.CantMoveCamera();
            Player_moverse.Instance.StopMove();

            // Move object towards camera
            float distance = Vector3.Distance(transform.position, Camera.main.transform.position);
            float step = moveSpeed * Time.deltaTime;
            Vector3 newPosition = Camera.main.transform.position + Camera.main.transform.forward * initialDistance;
            newPosition.y = originalPositionY;
            transform.position = Vector3.Lerp(transform.position, Camera.main.transform.position + Camera.main.transform.forward * initialDistance, step);
            distanceEntre = Vector3.Distance(transform.position, Camera.main.transform.forward * initialDistance);

            if (distanceEntre <= 7f && count > 1) // Change 0.1f to desired threshold for inspection position
            {

                Invoke("StopSpeed", 2f);
                count--;

            }
                                
            if (Input.GetKeyDown(KeyCode.E))
            {
                isInspecting = false;
                transform.position = originalPosition;
                transform.rotation = originalRotation;
                box.enabled = true;
                moveSpeed = 1f;
                activarObjetivo.Invoke();

                PlayerLook.Instance.MoveAgain();
                Player_moverse.Instance.MoveAgain();
                gameObject.SetActive(false);
            }
        }



    }
    protected override void Interact()
    {
        Debug.Log("Se interactuo con " + gameObject.name);

        isInspecting = true;
        originalPosition = transform.position;
        originalRotation = transform.rotation;
        originalPositionY = transform.position.y;
        count++;

    }
    private void StopSpeed()
    {
        moveSpeed = 0f;
    }
}
