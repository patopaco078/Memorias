using UnityEngine;

public class Player_Cam : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public Transform orientation;
    public Transform player;


    float xRotattion;
    float yRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible= false;
    }

    private void Update()
    {
        //inputs del mouse
        float mouseX = Input.GetAxisRaw("Mouse X")* Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;

        xRotattion -= mouseY;
        xRotattion = Mathf.Clamp(xRotattion, -90f, 90f);

        //rotate cam and orientation
        transform.rotation = Quaternion.Euler(xRotattion, yRotation, 0);
        orientation.rotation= Quaternion.Euler(0,yRotation, 0);
        player.rotation = Quaternion.Euler(0, yRotation, 0);





    }
}
