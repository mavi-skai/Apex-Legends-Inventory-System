using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLookAt : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerbody;
    float xRotation = 0f;
    public Camera fpsCam;
    public LayerMask layermask;
 


    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation,0f,0f);


        playerbody.Rotate(Vector3.up * mouseX);

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, 10, layermask))
        {
            // Debug.Log("test");
            if (hit.transform.GetComponent<ItemPickUp>() != null)
            {
                hit.transform.GetComponent<ItemPickUp>().ActivateCanvas();
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.collider.GetComponent<ItemPickUp>().PickUP();
                }
            }
            
        }
    }
}
