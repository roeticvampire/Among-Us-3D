using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseMovement : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField] private Transform playerBody;
    [SerializeField] private float mouseSensitivity=100f;

    float xRotation = 0f;
    void Start()
    {
         Cursor.lockState=CursorLockMode.Locked;           
    }

    // Update is called once per frame
    void Update()
    {
        if(SelectionManager.isWorkingOnTasks) return;
        float mouseX=Input.GetAxis("Mouse X")*mouseSensitivity*Time.deltaTime;
        float mouseY=Input.GetAxis("Mouse Y")*mouseSensitivity*Time.deltaTime;
        xRotation-=mouseY;
        xRotation=Mathf.Clamp(xRotation,-45f,45f);
   

        transform.localRotation= Quaternion.Euler(xRotation,0f,0f);
        playerBody.Rotate(Vector3.up * mouseX);



    }
}
