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
            // Ger information om "vad" vi har tr�ffat med via "ray" str�len
            RaycastHit hitInfo;

            // Physics.Raycast "testar" OM vi kolliderar med n�got p� v�r "ray" str�le
            // fr�n en position (origin) �t en viss riktning (direction) och ut f�r vi tv� saker
            // OM vi kolliderar med n�got s� returnerar IF satsen "true", annars "false"
            // och vi f�r ut via out hitInfo (som var RaycastHit) INFORMATION om VAD vi kolliderade med

            if (Physics.Raycast(transform.position, transform.forward, out hitInfo))
            {
                // Skriver ut "information" om objektet vi tr�ffade med via v�r Ray
                Debug.Log(hitInfo.collider.name);

                // Ritar ut en "hj�lplinje" som motsvarar v�r ray
                Debug.DrawRay(transform.position, transform.forward * hitInfo.distance, Color.red);
            }
            else
            {
                Debug.DrawRay(transform.position, transform.forward * 20f, Color.red);
            }
        }
    }
}
