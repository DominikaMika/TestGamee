using System;           // NOTERA: Vi m�ste inkluder System h�r f�r att f� access till "Action"
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
                // H�r utl�ser vi eller s.k. "triggar" vi h�ndelsen
                onDoorwayTriggerEnter();
            }
        }

        public void DoorTriggerExit()
        {
            if (onDoorwayTriggerExit != null)
            {
                // H�r utl�ser vi eller s.k. "triggar" vi h�ndelsen
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