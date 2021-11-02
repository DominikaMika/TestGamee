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
            // Exempel 1) Vi visar hur man förflyttar med character controller
            /*
            float rotY = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");

            Vector3 moveDirection = new Vector3(0, 0, moveZ);

            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed * Time.deltaTime;

            // här är characters kommando för förflyttning
            charController.Move(moveDirection);

            // Beräkna lite hastigheten för rotationen
            rotY = rotY * rotationSpeed * Time.deltaTime;

            // Utför själva rotationen
            transform.Rotate(0, rotY, 0);
            */


            // Exempel 2) Här tar vi även med "Jump"

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

            // här utför vi vår egna simulerande gravitationsberäkning
            moveDirection.y -= gravity * Time.deltaTime;

            /// NEW ///

            // här är characters kommando för förflyttning
            charController.Move(moveDirection);

            // Beräkna lite hastigheten för rotationen
            rotY = rotY * rotationSpeed * Time.deltaTime;

            // Utför själva rotationen
            transform.Rotate(0, rotY, 0);

            */

            // Exempel 3) Här är ett annat sätt att förflytta vår karaktär
            // med character controller som också tar hänsyn till att vi INTE
            // kan hålla ned knapptryckningen för jump och fortsätta uppåt
            // utan vi kan bara trycka ned knappen en gång. Vi använder 
            // sedan isGrounded för att säkra att vi hoppar från marken
            // sedan OnColliderEnter för att nollställa isGrounded när vi landar igen.
            /*
            float rotY = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");

            Vector3 moveDirection = new Vector3(0, 0, moveZ);

            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed * Time.deltaTime;

            /// NEW ///
            // Notera att vi drar nytta av character controller sätt att mäta om vi kolliderat
            // med marken eller ej. MEN lägg märke här till att vi får en "spik" och ett ryckigt 
            // upphopp.

            if (Input.GetButtonDown("Jump") && charController.isGrounded)
            {
                moveDirection.y = jumpSpeed;
            }
            else
            {
                // här utför vi vår egna simulerande gravitationsberäkning
                moveDirection.y -= gravity * Time.deltaTime;
            }

            /// NEW ///

            // här är characters kommando för förflyttning
            charController.Move(moveDirection);

            // Beräkna lite hastigheten för rotationen
            rotY = rotY * rotationSpeed * Time.deltaTime;

            // Utför själva rotationen
            transform.Rotate(0, rotY, 0);
            */

            // Exempel 4) Vi fortsätter utveckla hoppet med hjälp av
            // character controller komponenten
            // I detta exempel förbättrar vi hoppet, så detta bort omedelbart hopp och
            // och får en mjukare hopp. 

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

            // här är characters kommando för förflyttning
            charController.Move(moveDirection * Time.deltaTime);

            // Beräkna lite hastigheten för rotationen
            rotY = rotY * rotationSpeed * Time.deltaTime;

            // Utför själva rotationen
            transform.Rotate(0, rotY, 0);
        }

    }
}