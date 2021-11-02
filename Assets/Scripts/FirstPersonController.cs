using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
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
