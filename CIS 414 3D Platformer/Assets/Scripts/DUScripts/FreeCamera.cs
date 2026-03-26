using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeCamera : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public float lookXLimit = 80f; // Limit vertical camera rotation

    private float xRotation = 0f;

    void Start()
    {
        // Lock the cursor to the center of the screen and hide it
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Vertical camera rotation (clamped)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -lookXLimit, lookXLimit);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Horizontal player rotation
        transform.parent.Rotate(Vector3.up * mouseX);
    }
}
