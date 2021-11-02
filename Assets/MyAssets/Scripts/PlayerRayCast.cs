using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyAssets { 

    public class PlayerRayCast : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            // Ger information om "vad" vi har träffat med via "ray" strålen
            RaycastHit hitInfo;

            // Physics.Raycast "testar" OM vi kolliderar med något på vår "ray" stråle
            // från en position (origin) åt en viss riktning (direction) och ut får vi två saker
            // OM vi kolliderar med något så returnerar IF satsen "true", annars "false"
            // och vi får ut via out hitInfo (som var RaycastHit) INFORMATION om VAD vi kolliderade med

            if (Physics.Raycast(transform.position, transform.forward, out hitInfo))
            {
                // Skriver ut "information" om objektet vi träffade med via vår Ray
                Debug.Log(hitInfo.collider.name);

                // Ritar ut en "hjälplinje" som motsvarar vår ray
                Debug.DrawRay(transform.position, transform.forward * hitInfo.distance, Color.red);
            }
            else
            {
                Debug.DrawRay(transform.position, transform.forward * 20f, Color.red);
            }
        }
    }
}
