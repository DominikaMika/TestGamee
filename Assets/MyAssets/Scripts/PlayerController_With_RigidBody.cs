using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyAssets
{

    /// <summary>
    /// Denna klass för att styra playerkontroller använder RigidBody
    /// och därmed kan vi använda krafter för att styra vår player med.
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
            // Exempel 1) här hoppar vi uppåt när vi trycker ned space-tagenten
            // Vi använder oss av här AddForce vilket är en metod som finns tillgänglig
            // så fort vi lägger till "RigidBody". AddForce påverkar vårt objekt med en s.k. "Kraft"
            // i någon riktning och här påverkar den längs y-axeln dvs uppåt
            // Så här är vårt första försök till "jump"


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


            // Exempel 2) Här använder vi Force för att accelerera vår karaktär
            // 
            /*
             float xMovement = Input.GetAxis("Horizontal");
             float zMovement = Input.GetAxis("Vertical");

             movement = new Vector3(0, 0, zMovement);

             // If-satsen här säger att vi endast förflyttar om vi hade tryckt
             // ned någon tagenttryckning ovan. 
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

            // Alternativ till "tag" är att använda s.k. "layer" istället
            // så här skriver vi ovan samma sats men med layer
            // Notera att ordet "Ground" här är INTE det som vi definierade isåfall 
            // för tag-listan utan under layer-listan.
            // (Layer ligger åt höger om Tag under Inspector fönstret)
            // Fördelen då ? layers är något vi kommer dra nytta av för VR delen senare
            // men fördelen är att ett gameobjekt kan ha flera layers tillskillnad
            // mot att ett gameobject bara kan ha en tag. 
            /*
             if (collision.gameObject.layer == LayerMask.GetMask("Ground") && !isGrounded) {
                isGround = true;
            }
            */

        }
    }
}