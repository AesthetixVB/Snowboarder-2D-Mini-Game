using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    [Header("Audio Clip")]
    public AudioClip background;
    public AudioClip crash;
    public AudioClip finish;
    public AudioClip trail;

    void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
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
