using UnityEngine;

public class CustomizeManager : MonoBehaviour
{
    [SerializeField] private CustomInfo customInfo;

    public void SetCustomMusic(AudioClip audioClip)
    {
        customInfo.backgroundMusic = audioClip;
    }

    public void SetCustomBackground(Sprite sprite)
    {
        customInfo.backgroundImage = sprite;
    }
}
