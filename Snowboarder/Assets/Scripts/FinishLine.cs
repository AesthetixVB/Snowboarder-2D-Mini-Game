using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float loadDelay = 1f;
    [SerializeField] ParticleSystem finishEffect;
    [SerializeField] bool goNextLevel;
    [SerializeField] string levelName; 
    //this is to note what level the next level will reload
    //doesn't actuallly change anything
    AudioManager audioManager;

    void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            finishEffect.Play();
            audioManager.PlaySFX(audioManager.finish);
            if(goNextLevel)
            {
                Invoke("NextScene", loadDelay);
            }
            else
            {
                Invoke("ReloadScene", loadDelay);
            }
        
        }
    }

    void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
