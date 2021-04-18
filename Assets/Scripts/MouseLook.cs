using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] Transform player;
   [SerializeField] float mouseSensitivity;

    float xAxisClamp;

    private void Awake()
    {
        
        Cursor.lockState = CursorLockMode.Locked;
        xAxisClamp = 0;
        
    }

    private void Update()
    {
        
        RotateCamera();
    }



    void RotateCamera()
    {
        float mouseX = Input.GetAxisRaw("Mouse X");
        float mouseY = Input.GetAxisRaw("Mouse Y");

        float rotAmountX = mouseX * mouseSensitivity * Time.deltaTime;
        float rotAmountY = mouseY * mouseSensitivity * Time.deltaTime;


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
        player.Rotate(Vector3.up * mouseX);
    }


    void ClampXAxisRotationToValue(float value)
    {
        Vector3 eulerRot = transform.eulerAngles;
        eulerRot.x = value;
        transform.eulerAngles = eulerRot;
    }

}
