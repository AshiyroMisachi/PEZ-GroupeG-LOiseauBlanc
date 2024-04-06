using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class S_CameraFunction
{
    //Make the cursor disapear, if the cursor is already lock just unlock it
    public static void LockCursor()
    {
        if (Cursor.lockState != CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            return;
        }
        Cursor.lockState = CursorLockMode.None;
    }

    public static void SwitchCamera(Camera newCamera, Camera currentCamera)
    {
        newCamera.enabled = true;
        currentCamera.enabled = false;
    }
}
