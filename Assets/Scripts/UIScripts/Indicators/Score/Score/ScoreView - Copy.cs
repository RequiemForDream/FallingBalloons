using TMPro;
using UnityEngine;

namespace UIElements
{
    [RequireComponent(typeof(TMP_Text))]      
    public class ScoreView : MonoBehaviour
    {
        private TMP_Text scoreText;

        private void Start()
        {
            scoreText = GetComponent<TMP_Text>();
        }

        public void SetScore(int value)
        {           
            scoreText.text = value.ToString();
        }
    }
}


