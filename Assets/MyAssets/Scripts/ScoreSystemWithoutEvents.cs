using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace MyAssets
{
    public class ScoreSystemWithoutEvents : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text score;

        private int _score;

        // Start is called before the first frame update
        void Start()
        {
            // Nollst�ll alltid po�ngen med 0 vid start
            _score = 0;
        }

        public void increaseScore()
        {
            // R�kna p� en po�ng
            _score++;

            // Skriv ut po�ngen p� sk�rmen
            score.text = "Score : " + _score.ToString();
        }
    }
}
