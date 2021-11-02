using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace MyAssets
{
    public class ScoreSystemWithEvents : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text score;

        private int _score;

        // Start is called before the first frame update
        void Start()
        {
            // Nollställ alltid poängen med 0 vid start
            _score = 0;

            GameEvents.current.onCoinTriggerEnter += Current_onCoinTriggerEnter;
        }

        private void OnDestroy()
        {
            GameEvents.current.onCoinTriggerEnter -= Current_onCoinTriggerEnter;
        }

        private void Current_onCoinTriggerEnter()
        {
            increaseScore();
        }

        private void increaseScore()
        {
            // Räkna på en poäng
            _score++;

            // Skriv ut poängen på skärmen
            score.text = "Score : " + _score.ToString();
        }
    }
}
