using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float loadDelay = 2f;
    [SerializeField] ParticleSystem crashParticles;
    //[SerializeField] AudioClip crashSFX;
    AudioManager audioManager;

    bool hasCrashed = false;
    
    void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Ground" && !hasCrashed)
        {
            hasCrashed = true;
            FindObjectOfType<PlayerController>().DisableControls();
            crashParticles.Play();
            audioManager.PlaySFX(audioManager.crashSFX);
            Invoke("ReloadScene", loadDelay);
        }
    }
    
    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
