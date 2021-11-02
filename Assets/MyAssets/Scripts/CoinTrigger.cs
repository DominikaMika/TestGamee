using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyAssets
{
    public class CoinTrigger : MonoBehaviour
    {

        [SerializeField]
        private ScoreSystemWithoutEvents refToScore;

        // Start is called before the first frame update
        void Start()
        {

        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Debug.Log("Player collected a Coin");

                refToScore.increaseScore();

                Destroy(gameObject);
            }
        }
    }
}