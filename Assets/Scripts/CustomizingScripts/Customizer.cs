using UnityEngine;
using UnityEngine.UI;

public class Customizer : MonoBehaviour
{
    [SerializeField] private CustomInfo customInfo;
    [SerializeField] private Image backGroundSprite;

    private void Start()
    {
        backGroundSprite.sprite = customInfo.backgroundImage;
    }
}
