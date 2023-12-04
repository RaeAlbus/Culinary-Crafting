using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitialInstructionManager : MonoBehaviour
{
    public GameObject popupPanel;
    public Text messageText;
    public Button exitButton;
    public Image popupImage;

    private void Start()
    {
        // Initially, hide the pop-up
        popupPanel.SetActive(false);

        // Set up the exit button click event
        exitButton.onClick.AddListener(ClosePopup);
    }

    public void ShowPopup(string message, Sprite popupSprite)
    {
        // Set the message text
        messageText.text = message;

        // Set the sprite
        popupImage.sprite = popupSprite;

        // Show the pop-up
        popupPanel.SetActive(true);
    }

    private void ClosePopup()
    {
        // Hide the pop-up
        popupPanel.SetActive(false);
    }
}