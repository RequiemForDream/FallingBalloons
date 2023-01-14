using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{   
    [SerializeField] private CustomInfo customInfo;
    [SerializeField] private AudioClip popSound;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        EventBus.OnBalloonPoped += PlayPopSound;
    }

    private void Start()
    {           
        audioSource.PlayOneShot(customInfo.backgroundMusic);       
    }

    private void PlayPopSound()
    {
        audioSource.PlayOneShot(popSound);
    }

    private void OnDestroy()
    {
        EventBus.OnBalloonPoped -= PlayPopSound;
    }
}
