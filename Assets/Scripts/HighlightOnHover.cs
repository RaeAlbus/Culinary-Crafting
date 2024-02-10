using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightOnHover : MonoBehaviour
{
    private Color originalColor;
    public Color highlightColor = Color.white;
    private SpriteRenderer spriteRenderer;
    private AudioSource audioSource;
    public AudioClip hoverSound;

    void Start()
    {
        // Get the SpriteRenderer component of the ingredient
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            // Store the original color of the sprite
            originalColor = spriteRenderer.color;
        }

        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.clip = hoverSound;
    }

    void OnMouseEnter()
    {

        if (spriteRenderer != null)
        {
            if (audioSource != null && hoverSound != null)
            {
                audioSource.Play();
            }
            // Change the color to the highlight color when the mouse enters
            spriteRenderer.color = highlightColor;
        }
    }

    void OnMouseExit()
    {
        // Reset the color to the original color when the mouse exits
        if (spriteRenderer != null)
        {
            spriteRenderer.color = originalColor;
        }
    }
}
