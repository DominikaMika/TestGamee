using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInteraction : MonoBehaviour
{
    Ray ray;
    RaycastHit hitInfo;

    void Update()
    {
        // L�s av fr�n "screenspace" och skapa en str�le 
        // anv�nd musens position fr�n vart ni befinner er p� sk�rmen
        // och kasta str�len in i worldspace
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Anv�nd �ter physics.raycast f�r att l�sa av om vi fick n�gon "tr�ff" 
        // och is�fall returnera tillbaks information om objektet vi tr�ffade
        if (Physics.Raycast(ray, out hitInfo))
        {
            // MEN se till att vi bara �r intresserade att g�ra n�got med detta
            // om vi samtidigt klickade ned p� musknappen
            if (Input.GetMouseButtonDown(0))
            {
                // H�r skriver bara ut namnet p� det vi klickade p�
                Debug.Log(hitInfo.collider.name);
            }
        }
    }
}
