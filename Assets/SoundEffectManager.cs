using System;
using UnityEngine;
using UnityEngine.UI;

public class SoundEffectManager : MonoBehaviour
{
    private static SoundEffectManager instance;
    private static AudioSource audioSource;
    private static AudioLibrary audioLibrary;
    [SerializeField] private Slider sfxSlider;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            audioSource = GetComponent<AudioSource>();
            audioLibrary = GetComponent<AudioLibrary>();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public static void Play(string audioName)
    {
        AudioClip audioClip = audioLibrary.GetAudioClip(audioName);
        if (audioClip != null)
        {
            audioSource.PlayOneShot(audioClip);
        }
    }

    private void Start()
    {
        if (sfxSlider != null)
        {
            sfxSlider.onValueChanged.AddListener(delegate { OnValueChanged(); });
        }
    }

    public static void setVolume(float volume)
    {
        audioSource.volume = volume;
    }

    public void OnValueChanged()
    {
        setVolume(sfxSlider.value);
    }
}