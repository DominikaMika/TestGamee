using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyAssets
{

    /// <summary>
    /// NEW : RequireComponent nedan ovanf�r klassen PlayerMovement
    /// g�r att vi tvingar det gameobject som detta skript �r knutet till
    /// att ha en CharacterController komponent tillagd f�r att kunna
    /// fungera/k�ras. Annars blir det ett error. Detta bara
    /// f�r att vi ska garantera att vi har en CharacterController komponent
    /// s� man inte missar det eller r�kar ta bort den.
    /// </summary>
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovement_CharacterController : MonoBehaviour
    {
        [SerializeField]
        private float moveSpeed;

        [SerializeField]
        private float jumpSpeed;

        [SerializeField]
        private float gravity = -9.82f;

        // Till exempel 2
        [SerializeField]
        private Transform groundCheck;

        // Till exempel 2
        [SerializeField]
        private float groundDistance = 0.4f;

        // Till exempel 2
        [SerializeField]
        private LayerMask groundMask;


        private CharacterController cc;

        private Vector3 velocity;

        // Till exempel 2
        private bool isGrounded;

        // Start is called before the first frame update
        void Start()
        {
            cc = GetComponent<CharacterController>();

        }

        // Update is called once per frame
        void Update()
        {
            // Exempel 1)
            // som vanligt anv�nder vi piltagenterna eller 
            // tagenterna W,A,S och D f�r att l�sa av f�r f�rflyttning
            /*
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 movement = transform.right * x + transform.forward * z;

            cc.Move(movement * moveSpeed * Time.deltaTime);
            */

            // Exempel 2)
            // Precis som f�rut s� arbetade vid med Jump och Gravitationen
            // f�r v�r 3rd person character, och samma principer g�ller
            // �ven f�r v�r 1st person character som skapar h�r med.

            //// NEW /////
            // Denna del l�ser av om detta objekt kolliderar med 
            // andra objekt eller ej genom att anv�nda en s.k. "ray"
            // dvs en str�le som m�ter av om den tr�ffar n�got annat
            // layerMask anger "vad" den �r intresserad av att kolla
            // om den tr�ffar med eller ej. 
            // OM vi kolliderar med vad layerMask pekade p�
            // s� returneras v�rdet sant annars falskt om vi inte tr�ffade just detta objekt
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if (isGrounded && velocity.y < 0.0f)
            {
                velocity.y = 0.0f;
            }

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 movement = transform.right * x + transform.forward * z;

            cc.Move(movement * moveSpeed * Time.deltaTime);

            velocity.y += gravity * Time.deltaTime;

            cc.Move(velocity * Time.deltaTime);

        }
    }
}