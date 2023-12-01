using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightOnHover : MonoBehaviour
{
    private Color originalColor;
    public Color highlightColor = Color.yellow;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        // Get the SpriteRenderer component of the object
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            // Store the original color of the sprite
            originalColor = spriteRenderer.color;
        }
    }

    void OnMouseEnter()
    {
        // Check if the mouse is over the object
        if (spriteRenderer != null)
        {
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
