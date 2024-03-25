using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_PlayerCamera : MonoBehaviour
{
    //Rotation speed of the Camera
    [SerializeField]
    private float mouseSensivity = 100f;

    //Reference of the Player Transform
    [SerializeField]
    private Transform playerBody;

    //Current xRotation of the Camera
    private float xRotation;

    void Start()
    {
        //Lock the cursor at the start of the game
        S_CameraFunction.LockCursor();
    }

    void Update()
    {
        if (S_ManagerManager.GetManager<S_PlayerManager>().GetPlayerState() != PlayerState.Exploration)
        {
            return;
        }
        //Move the Camera each frame
        MoveCameraView();
    }

    private void MoveCameraView()
    {
        //Get Axis value of the Cursor      Multiplied with Sensitivity   And deltaTime to work with all frameRate
        float mouseX = Input.GetAxis("Mouse X") * mouseSensivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensivity * Time.deltaTime;

        //Stock xRotation modified by Y axis of the mouse
        xRotation -= mouseY;
        //Clamp make xRotation didn't exceed certain value
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        //xRotation is for the PlayerCamera only
        transform.localEulerAngles = new Vector3(xRotation, 0f, 0f);

        //Rotate the player based on X axis of the mouse
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
