using UnityEngine;
using UIElements;

public class HealthManager : MonoBehaviour
{       
    [Header("Health Visual")]
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private HealthView healthView;

    private float health;

    private void Start()
    {
        health = 100;
        EventBus.OnDestroyByFall += DecreaseHealth;
    }

    private void DecreaseHealth(float damage)
    {
        health -= damage;
        if (health < 0)
        {
            EventBus.SendGameOver();
            health = 0;
        }         
            
        healthView.SetHealth(health);
        healthBar.SetHealthLevel(health);           
    }

    private void OnDisable()
    {
        EventBus.OnDestroyByFall -= DecreaseHealth;
    }
}



