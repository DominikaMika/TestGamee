using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    [SerializeField]
    private Transform playerBody;
    [SerializeField]
    private float mouseSensitivity = 100f;

    private float xRotation = 90f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float rotY = Input.GetAxis("Mouse X");
        float rotX = Input.GetAxis("Mouse Y");

        xRotation -= rotX * mouseSensitivity * Time.deltaTime;

        //"Klipper av" v�rdet s� vi inte roterar
        // mer 'n 180 grader och g�r en "volt" med kameran. Klippning kallas f�r clamping
        xRotation = Mathf.Clamp(xRotation, -40.0f, 40.0f);

        // Roterar kring x-axeln (upp/ned)
        transform.localRotation = Quaternion.Euler(xRotation, 0.0f, 0.0f);

        // Roterar kring y-axeln (v�nster/h�ger)
        playerBody.Rotate(Vector3.up * rotY * mouseSensitivity * Time.deltaTime);
    }
}
