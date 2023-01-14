using TMPro;
using UnityEngine;

namespace UIElements
{
    [RequireComponent(typeof(TMP_Text))]
    public class HighScoreView : MonoBehaviour
    {
        private TMP_Text highScoreText;
        private int highScore;

        private void Awake()
        {
            if (PlayerPrefs.HasKey("SaveHighScore"))
                highScore = PlayerPrefs.GetInt("SaveHighScore");
        }

        private void Start()
        {            
            highScoreText = GetComponent<TMP_Text>();
            highScoreText.text = "High score:" + highScore.ToString();
        }

        public void SetScore(int score)
        {
            if (highScore < score)
            {
                highScore = score;
                PlayerPrefs.SetInt("SaveHighScore", highScore);
                highScoreText.text = "High score:" + highScore.ToString();                                               
            }
        }
    }
}

