using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    //A script for looking around the scene, using mouse input.

    //sensitivity when looking around
    public float mouseSensitivity = 100f;

    //The player character's position and rotation
    public Transform playerBody;

    //stores current camera rotation about the x axis.
    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        //calculates how far the camera is looking up/down
        xRotation -= mouseY;
        //Locks the camera so it can't look further than straight up & straight down
        //(prevents looking behind/spinning the camera wildly)
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //rotates the camera up and down according to Y input
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        //rotates the player model the camera is attached to.
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
