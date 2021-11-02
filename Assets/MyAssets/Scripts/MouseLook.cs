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
            // Denna del �r valfritt men 
            // g�r s� att vi "l�ser" muspekaren till att befinna
            // sig fix i mitten av sk�rmen n�r vi startar
            Cursor.lockState = CursorLockMode.Locked;
        }

        // Update is called once per frame
        void Update()
        {
            // Exempel 1)
            // Vi l�ser av fr�n musen ist�llet och utifr�n mouseX och mouseY
            // v�rdet vi f�r s� roterar vi kring x-axeln respektive y-axeln
            // s� vi kan r�ra v�r "kamera" freely dvs fritt, beroende
            // p� hur vi f�rflyttar musen n�r vi startar.

            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            xRotation -= mouseY * mouseSensitivity * Time.deltaTime;

            // Denna del "klipper av" v�rdet s� vi inte roterar 
            // mer �n 180 grader och g�r en "volt" med kameran.
            // n�r man klipper v�rdet s� h�r kallas det f�r clamping.
            xRotation = Mathf.Clamp(xRotation, -90.0f, 90.0f);

            // Roterar kring x-axeln (upp / ned)
            transform.localRotation = Quaternion.Euler(xRotation, 0.0f, 0.0f);

            // Roterar kring y-axeln (v�nster / h�ger)
            playerBody.Rotate(Vector3.up * mouseX * mouseSensitivity * Time.deltaTime);

        }
    }
}