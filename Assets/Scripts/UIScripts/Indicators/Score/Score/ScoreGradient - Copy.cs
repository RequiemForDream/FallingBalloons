using UnityEngine;
using UnityEngine.UI;

namespace UIElements
{
    [RequireComponent(typeof(Image))]
    public class ScoreGradient : MonoBehaviour
    {
        [SerializeField] private Gradient gradient;
        private Image scoreViewImage;
        

        private void Start()
        {
            scoreViewImage = GetComponent<Image>();
        }

        public void OnScoreChanged(int valueAsPercantage)
        {
            float f = (float)valueAsPercantage;
            scoreViewImage.color = gradient.Evaluate(f / 10000);
        }
    }
}

