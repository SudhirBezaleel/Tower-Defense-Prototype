using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSToggle : MonoBehaviour
{
    public GameObject overheadCam;
    public GameObject FPSCam;
    public GameObject FPSCanvas;

    private bool fpsMode = true;

    void Start()
    {
        overheadCam.SetActive(false);
        FPSCam.SetActive(true);
        FPSCanvas.SetActive(true);

        // Lock the cursor at start (FPS mode)
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (fpsMode)
            {
                // We are currently in FPS mode, so switch to overhead mode
                fpsMode = false;

                overheadCam.SetActive(true);
                FPSCam.SetActive(false);
                FPSCanvas.SetActive(false);

                // Unlock and show cursor for overhead mode
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                // We are currently in overhead mode, so switch to FPS mode
                fpsMode = true;

                overheadCam.SetActive(false);
                FPSCam.SetActive(true);
                FPSCanvas.SetActive(true);

                // Lock and hide cursor for FPS mode
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }
}
