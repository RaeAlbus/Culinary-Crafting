using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    private static BackgroundMusic instance;
    private AudioSource audioSource;

    void Start()
    {
        if (instance == null)
        {
            // This is the first instance of the script, so make it the singleton instance
            instance = this;

            // Mark this GameObject to persist across scene changes
            DontDestroyOnLoad(gameObject);

            // Initialize and play the background music
            audioSource = GetComponent<AudioSource>();
            audioSource.Play();
        }
        else
        {
            // Another instance of the script already exists, so destroy this one
            Destroy(gameObject);
        }
    }

    void Update()
    {
        // Check if the audio has finished playing
        if (!audioSource.isPlaying)
        {
            // If it has finished, restart it
            audioSource.Play();
        }
    }
}