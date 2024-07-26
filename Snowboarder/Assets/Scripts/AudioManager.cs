using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    
    [Header("Audio Source")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    [Header("Audio Clip")]
    public AudioClip backgroundMusic;
    public AudioClip crashSFX;
    public AudioClip finishSFX;
    public AudioClip trailSFX;

    void Start()
    {

        musicSource.clip = backgroundMusic;
        musicSource.Play();
        
    }
    void Awake()
    {
        if (instance == null)
        {

            instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {

            Destroy(gameObject);

        }
    }
    public void PlaySFX(AudioClip clip)
    {
        
        SFXSource.PlayOneShot(clip);
        SFXSource.mute = false;
        
    }
    public void StopSFX(AudioClip clip)
    {

        SFXSource.mute = true;

    }
}
