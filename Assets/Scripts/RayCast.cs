using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    [SerializeField]
    LayerMask _interactionMask;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = new Ray(transform.position, transform.forward);

            /*
            int mask = LayerMask.GetMask("RedCube");

            if (Physics.Raycast(ray, 40, _interactionMask))
            {
                Debug.Log("Collision hit: " + _interactionMask.value);
                Debug.DrawRay(transform.position, transform.forward, Color.red);
            }
            */

            // Exempel 2

            RaycastHit hitInfo;

            LayerMask mask = LayerMask.GetMask("Shields");
            //int mask = 1 << _interactionMask;

            if (Physics.Raycast(ray, out hitInfo, 10, mask))
            {
                //Debug.Log(hitInfo.collider.name);
                //Debug.DrawRay(transform.position, transform.forward * hitInfo.distance, Color.red);
            }
        }
            
    }
}
