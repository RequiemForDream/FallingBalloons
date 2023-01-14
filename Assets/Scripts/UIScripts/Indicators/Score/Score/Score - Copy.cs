using UnityEngine;

namespace UIElements
{
    public class Score : MonoBehaviour
    {
        [Header("Score Visual")]
        [SerializeField] private ScoreView scoreView;
        [SerializeField] private ScoreGradient scoreGradient;
        [SerializeField] private HighScoreView highScoreView;

        private int score;

        private void Start()
        {
            score = 0;
            EventBus.OnDestroyByPlayer += IncreaseScore;
        }

        private void IncreaseScore(int score)
        {
            this.score += score;
            scoreGradient.OnScoreChanged(this.score);
            scoreView.SetScore(this.score);
            highScoreView.SetScore(this.score);
        }

        private void OnDisable()
        {
            EventBus.OnDestroyByPlayer -= IncreaseScore;
        }
    }
}



