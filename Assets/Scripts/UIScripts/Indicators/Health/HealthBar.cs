using UnityEngine;
using UnityEngine.UI;

namespace UIElements 
{
    [RequireComponent(typeof(Image))]
    public class HealthBar : MonoBehaviour
    {
        private Image healthBar;

        private void Start()
        {
            healthBar = GetComponent<Image>();
        }

        public void SetHealthLevel(float health)
        {
            healthBar.fillAmount = (health / 100);
        }
    }
}


