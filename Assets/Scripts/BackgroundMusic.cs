using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    private static BackgroundMusic bgMusic;
    private AudioSource audioSource;

    void Start()
    {
        // Initializes and plays the background music
        if (bgMusic == null)
        {
            bgMusic = this;

            DontDestroyOnLoad(gameObject);

            audioSource = GetComponent<AudioSource>();
            audioSource.Play();
        }
        else
        {
            // Destroys instance if another instance already exists
            Destroy(gameObject);
        }
    }

    void Update()
    {
        // Checks if the audio has finished playing - restarts if it has
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}