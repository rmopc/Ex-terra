using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simpleMouseLook : MonoBehaviour
{
    Vector2 rotation = Vector2.zero;
    public float speed = 3;
    public float minimumX = 90F;
    public float maximumX = 270F;
    public float minimumY = 5F;
    public float maximumY = 5F;
    float rotationY = -26.29F;
    float rotationX = 180F;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void Start()
    {
        //transform.localEulerAngles = new Vector3(-26.29F, 180F, 0);
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }

    void Update()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
        rotationX += Input.GetAxis("Mouse X");
        //rotationX = Mathf.Clamp(rotationX, minimumX, maximumX);
        rotationY += Input.GetAxis("Mouse Y");
        rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);
        transform.localEulerAngles = new Vector3(rotationY, rotationX, 0);
    }
}
