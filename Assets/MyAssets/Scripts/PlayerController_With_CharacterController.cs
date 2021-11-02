using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyAssets
{

    public class PlayerController_With_CharacterController : MonoBehaviour
    {
        [SerializeField]
        private float speed;

        [SerializeField]
        private float rotationSpeed;

        [SerializeField]
        private float jumpSpeed;

        [SerializeField]
        private float gravity = 9.82f;

        private bool isGrounded = true;

        private CharacterController charController;

        private float originalStepOffset;

        private Vector3 velocity;

        private float directionY = 0.0f;

        // Start is called before the first frame update
        void Start()
        {
            charController = GetComponent<CharacterController>();
            if (!charController)
            {
                Debug.LogError("You missing the character controller component");
                return;
            }

            originalStepOffset = charController.stepOffset;

        }

        // Update is called once per frame
        void Update()
        {
            // Exempel 1) Vi visar hur man f�rflyttar med character controller
            /*
            float rotY = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");

            Vector3 moveDirection = new Vector3(0, 0, moveZ);

            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed * Time.deltaTime;

            // h�r �r characters kommando f�r f�rflyttning
            charController.Move(moveDirection);

            // Ber�kna lite hastigheten f�r rotationen
            rotY = rotY * rotationSpeed * Time.deltaTime;

            // Utf�r sj�lva rotationen
            transform.Rotate(0, rotY, 0);
            */


            // Exempel 2) H�r tar vi �ven med "Jump"

            /*
            float rotY = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");

            Vector3 moveDirection = new Vector3(0, 0, moveZ);

            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed * Time.deltaTime;

            /// NEW ///
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed * Time.deltaTime;
            }

            // h�r utf�r vi v�r egna simulerande gravitationsber�kning
            moveDirection.y -= gravity * Time.deltaTime;

            /// NEW ///

            // h�r �r characters kommando f�r f�rflyttning
            charController.Move(moveDirection);

            // Ber�kna lite hastigheten f�r rotationen
            rotY = rotY * rotationSpeed * Time.deltaTime;

            // Utf�r sj�lva rotationen
            transform.Rotate(0, rotY, 0);

            */

            // Exempel 3) H�r �r ett annat s�tt att f�rflytta v�r karakt�r
            // med character controller som ocks� tar h�nsyn till att vi INTE
            // kan h�lla ned knapptryckningen f�r jump och forts�tta upp�t
            // utan vi kan bara trycka ned knappen en g�ng. Vi anv�nder 
            // sedan isGrounded f�r att s�kra att vi hoppar fr�n marken
            // sedan OnColliderEnter f�r att nollst�lla isGrounded n�r vi landar igen.
            /*
            float rotY = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");

            Vector3 moveDirection = new Vector3(0, 0, moveZ);

            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed * Time.deltaTime;

            /// NEW ///
            // Notera att vi drar nytta av character controller s�tt att m�ta om vi kolliderat
            // med marken eller ej. MEN l�gg m�rke h�r till att vi f�r en "spik" och ett ryckigt 
            // upphopp.

            if (Input.GetButtonDown("Jump") && charController.isGrounded)
            {
                moveDirection.y = jumpSpeed;
            }
            else
            {
                // h�r utf�r vi v�r egna simulerande gravitationsber�kning
                moveDirection.y -= gravity * Time.deltaTime;
            }

            /// NEW ///

            // h�r �r characters kommando f�r f�rflyttning
            charController.Move(moveDirection);

            // Ber�kna lite hastigheten f�r rotationen
            rotY = rotY * rotationSpeed * Time.deltaTime;

            // Utf�r sj�lva rotationen
            transform.Rotate(0, rotY, 0);
            */

            // Exempel 4) Vi forts�tter utveckla hoppet med hj�lp av
            // character controller komponenten
            // I detta exempel f�rb�ttrar vi hoppet, s� detta bort omedelbart hopp och
            // och f�r en mjukare hopp. 

            float rotY = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");

            Vector3 moveDirection = new Vector3(0, 0, moveZ);

            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;

            if (Input.GetButtonDown("Jump") && charController.isGrounded)
            {

                directionY = jumpSpeed;
            }

            directionY -= gravity * Time.deltaTime;

            moveDirection.y = directionY;

            // h�r �r characters kommando f�r f�rflyttning
            charController.Move(moveDirection * Time.deltaTime);

            // Ber�kna lite hastigheten f�r rotationen
            rotY = rotY * rotationSpeed * Time.deltaTime;

            // Utf�r sj�lva rotationen
            transform.Rotate(0, rotY, 0);
        }

    }
}