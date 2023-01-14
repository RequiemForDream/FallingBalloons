using UnityEngine;
using TMPro;

namespace UIElements 
{
    [RequireComponent(typeof(TMP_Text))]
    public class HealthView : MonoBehaviour
    {
        private TMP_Text healthAmount;
        
        private void Start()
        {
            healthAmount = GetComponent<TMP_Text>();
        }

        public void SetHealth(float health)
        {
            healthAmount.text = Mathf.Round(health).ToString();    
        }
    }
}


