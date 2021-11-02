using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyAssets
{

    /// <summary>
    /// NEW : RequireComponent nedan ovanför klassen PlayerMovement
    /// gör att vi tvingar det gameobject som detta skript är knutet till
    /// att ha en CharacterController komponent tillagd för att kunna
    /// fungera/köras. Annars blir det ett error. Detta bara
    /// för att vi ska garantera att vi har en CharacterController komponent
    /// så man inte missar det eller råkar ta bort den.
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
            // som vanligt använder vi piltagenterna eller 
            // tagenterna W,A,S och D för att läsa av för förflyttning
            /*
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 movement = transform.right * x + transform.forward * z;

            cc.Move(movement * moveSpeed * Time.deltaTime);
            */

            // Exempel 2)
            // Precis som förut så arbetade vid med Jump och Gravitationen
            // för vår 3rd person character, och samma principer gäller
            // även för vår 1st person character som skapar här med.

            //// NEW /////
            // Denna del läser av om detta objekt kolliderar med 
            // andra objekt eller ej genom att använda en s.k. "ray"
            // dvs en stråle som mäter av om den träffar något annat
            // layerMask anger "vad" den är intresserad av att kolla
            // om den träffar med eller ej. 
            // OM vi kolliderar med vad layerMask pekade på
            // så returneras värdet sant annars falskt om vi inte träffade just detta objekt
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