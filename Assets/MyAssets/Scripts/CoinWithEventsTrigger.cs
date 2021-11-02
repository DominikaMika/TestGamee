using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyAssets
{
    public class CoinWithEventsTrigger : MonoBehaviour
    {

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                GameEvents.current.CoinTriggerEnter();

                Destroy(gameObject);
            }
        }
    }
}
