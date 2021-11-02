using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInteraction : MonoBehaviour
{
    Ray ray;
    RaycastHit hitInfo;

    void Update()
    {
        // Läs av från "screenspace" och skapa en stråle 
        // använd musens position från vart ni befinner er på skärmen
        // och kasta strålen in i worldspace
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Använd åter physics.raycast för att läsa av om vi fick någon "träff" 
        // och isåfall returnera tillbaks information om objektet vi träffade
        if (Physics.Raycast(ray, out hitInfo))
        {
            // MEN se till att vi bara är intresserade att göra något med detta
            // om vi samtidigt klickade ned på musknappen
            if (Input.GetMouseButtonDown(0))
            {
                // Här skriver bara ut namnet på det vi klickade på
                Debug.Log(hitInfo.collider.name);
            }
        }
    }
}
