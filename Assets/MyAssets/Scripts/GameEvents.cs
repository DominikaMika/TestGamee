using System;           // NOTERA: Vi måste inkluder System här för att få access till "Action"
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyAssets
{

    public class GameEvents : MonoBehaviour
    {
        public static GameEvents current;

        public event Action onDoorwayTriggerEnter;
        public event Action onDoorwayTriggerExit;
        public event Action onCoinTriggerEnter;

        // Start is called before the first frame update
        void Awake()
        {
            current = this;
        }

        public void DoorTriggerEnter()
        {
            if (onDoorwayTriggerEnter != null)
            {
                // Här utlöser vi eller s.k. "triggar" vi händelsen
                onDoorwayTriggerEnter();
            }
        }

        public void DoorTriggerExit()
        {
            if (onDoorwayTriggerExit != null)
            {
                // Här utlöser vi eller s.k. "triggar" vi händelsen
                onDoorwayTriggerExit();
            }
        }

        public void CoinTriggerEnter()
        {
            if (onCoinTriggerEnter != null) {
                onCoinTriggerEnter();
            }
        }

    }
}