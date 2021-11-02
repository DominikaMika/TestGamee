using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyAssets
{

    /// <summary>
    /// Denna klass f�r att styra playerkontroller anv�nder RigidBody
    /// och d�rmed kan vi anv�nda krafter f�r att styra v�r player med.
    public class PlayerController_With_RigidBody : MonoBehaviour
    {
        [SerializeField]
        private float speed;

        [SerializeField]
        private float jumpForce;

        [SerializeField]
        private GroundCheck groundCheck;

        private Rigidbody playerBody;

        private Vector3 movement;
        private Vector3 inputVector;

        // Start is called before the first frame update
        void Start()
        {
            playerBody = GetComponent<Rigidbody>();

            if (playerBody == null)
            {
                Debug.LogError("You missing RigidBody in order to make it work!");
                return;
            }
        }

        bool isGrounded = true;

        // Update is called once per frame
        void Update()
        {
            // Exempel 1) h�r hoppar vi upp�t n�r vi trycker ned space-tagenten
            // Vi anv�nder oss av h�r AddForce vilket �r en metod som finns tillg�nglig
            // s� fort vi l�gger till "RigidBody". AddForce p�verkar v�rt objekt med en s.k. "Kraft"
            // i n�gon riktning och h�r p�verkar den l�ngs y-axeln dvs upp�t
            // S� h�r �r v�rt f�rsta f�rs�k till "jump"


            float xMovement = Input.GetAxis("Horizontal");
            float zMovement = Input.GetAxis("Vertical");

            movement = new Vector3(xMovement, 0.0f, zMovement);

            transform.Translate(movement * speed * Time.deltaTime);


            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                Debug.Log("jump");
                isGrounded = false;
                playerBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }


            // Exempel 2) H�r anv�nder vi Force f�r att accelerera v�r karakt�r
            // 
            /*
             float xMovement = Input.GetAxis("Horizontal");
             float zMovement = Input.GetAxis("Vertical");

             movement = new Vector3(0, 0, zMovement);

             // If-satsen h�r s�ger att vi endast f�rflyttar om vi hade tryckt
             // ned n�gon tagenttryckning ovan. 
             if (movement != Vector3.zero)
                 playerBody.AddForce(movement * Time.deltaTime, ForceMode.Impulse);
             */
        }

        private void OnCollisionEnter(Collision collision)
        {

            if (collision.gameObject.CompareTag("Ground") && !isGrounded)
            {
                isGrounded = true;
            }

            // Alternativ till "tag" �r att anv�nda s.k. "layer" ist�llet
            // s� h�r skriver vi ovan samma sats men med layer
            // Notera att ordet "Ground" h�r �r INTE det som vi definierade is�fall 
            // f�r tag-listan utan under layer-listan.
            // (Layer ligger �t h�ger om Tag under Inspector f�nstret)
            // F�rdelen d� ? layers �r n�got vi kommer dra nytta av f�r VR delen senare
            // men f�rdelen �r att ett gameobjekt kan ha flera layers tillskillnad
            // mot att ett gameobject bara kan ha en tag. 
            /*
             if (collision.gameObject.layer == LayerMask.GetMask("Ground") && !isGrounded) {
                isGround = true;
            }
            */

        }
    }
}