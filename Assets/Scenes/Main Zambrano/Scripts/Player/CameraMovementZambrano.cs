using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementZambrano : MonoBehaviour
{
    public static CameraMovementZambrano instance;
    
    [SerializeField] private GameObject cameraPos;
    [SerializeField] private GameObject player;

    [SerializeField] private float sensX;
    [SerializeField] private float sensY;

    private float yRotation = 180;
    private float xRotation;
    
    public bool ignoreMousePos;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    void Update()
    {

        transform.position = cameraPos.transform.position;
        
        if(ignoreMousePos)
            return;
        
        

        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime *sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime *sensY;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        
        
        transform.rotation = Quaternion.Euler(0, yRotation, -xRotation);
        player.transform.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
