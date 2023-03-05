using UnityEngine;
using UnityEngine.Events;

public class Player_Cam : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public Transform orientation;
    public Transform player;

    public bool canMove = true;

    private static Player_Cam _instance;
    public static Player_Cam Instance { get { return _instance; } }


    float xRotattion;
    float yRotation;


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
    }
    private void Start()
    {
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible= false;
    }

    private void Update()
    {
        if (canMove)
        {
            //inputs del mouse
            float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
            float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

            yRotation += mouseX;

            xRotattion -= mouseY;
            xRotattion = Mathf.Clamp(xRotattion, -90f, 90f);

            //rotate cam and orientation
            transform.rotation = Quaternion.Euler(xRotattion, yRotation, 0);
            orientation.rotation = Quaternion.Euler(0, yRotation, 0);
            player.rotation = Quaternion.Euler(0, yRotation, 0);
        }
       

    }

    private void MovementStatus()
    {
        if (canMove)
        {
            canMove = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else if (!canMove)
        {
            canMove = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        
        }
    }
   
}
