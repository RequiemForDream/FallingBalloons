using UnityEngine;

public class LosePanel : MonoBehaviour
{
    [SerializeField] private GameObject losePanel;  

    private void Awake()
    {
        losePanel.SetActive(true);
        EventBus.OnLosed += Lose;
    }

    private void Start()
    {
        losePanel.SetActive(false);
    }

    private void Lose()
    {
        losePanel.SetActive(true);
    }

    private void OnDestroy()
    {
        EventBus.OnLosed -= Lose;
    }
}
