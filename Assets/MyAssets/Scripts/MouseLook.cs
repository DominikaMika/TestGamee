using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyAssets
{

    public class MouseLook : MonoBehaviour
    {
        [SerializeField]
        private Transform playerBody;

        [SerializeField]
        private float mouseSensitivity = 100f;

        private float xRotation = 90f;

        // Start is called before the first frame update
        void Start()
        {
            // Denna del är valfritt men 
            // gör så att vi "låser" muspekaren till att befinna
            // sig fix i mitten av skärmen när vi startar
            Cursor.lockState = CursorLockMode.Locked;
        }

        // Update is called once per frame
        void Update()
        {
            // Exempel 1)
            // Vi läser av från musen istället och utifrån mouseX och mouseY
            // värdet vi får så roterar vi kring x-axeln respektive y-axeln
            // så vi kan röra vår "kamera" freely dvs fritt, beroende
            // på hur vi förflyttar musen när vi startar.

            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            xRotation -= mouseY * mouseSensitivity * Time.deltaTime;

            // Denna del "klipper av" värdet så vi inte roterar 
            // mer än 180 grader och gör en "volt" med kameran.
            // när man klipper värdet så här kallas det för clamping.
            xRotation = Mathf.Clamp(xRotation, -90.0f, 90.0f);

            // Roterar kring x-axeln (upp / ned)
            transform.localRotation = Quaternion.Euler(xRotation, 0.0f, 0.0f);

            // Roterar kring y-axeln (vänster / höger)
            playerBody.Rotate(Vector3.up * mouseX * mouseSensitivity * Time.deltaTime);

        }
    }
}