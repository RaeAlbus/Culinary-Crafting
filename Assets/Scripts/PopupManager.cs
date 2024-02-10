using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupManager : MonoBehaviour
{
    public GameObject popupPanel;
    public Text messageText;
    public Button exitButton;
    public Image popupImage;

    private void Start()
    {
        // Hides the pop-up
        popupPanel.SetActive(false);

        exitButton.onClick.AddListener(ClosePopup);
    }

    public void ShowPopup(string message, Sprite popupSprite)
    {
        // Sets the message text
        messageText.text = message;

        // Sets the sprite
        popupImage.sprite = popupSprite;

        // Shows the pop-up
        popupPanel.SetActive(true);
    }

    private void ClosePopup()
    {
        // Hides the pop-up
        popupPanel.SetActive(false);
    }
}