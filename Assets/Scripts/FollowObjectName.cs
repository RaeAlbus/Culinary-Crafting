using UnityEngine;
using UnityEngine.UI;

public class FollowObjectName : MonoBehaviour
{
    private Text nameText;
    private Canvas uiCanvas; // Reference to your existing canvas

    // Start is called before the first frame update
    void Start()
    {
        uiCanvas = FindObjectOfType<Canvas>();
        
        // Create a UI Text component dynamically
        CreateNameText();

        // Set the initial text to the GameObject name
        SetTextToGameObjectName();
    }

    // Update is called once per frame
    void Update()
    {
        // Update the position of the UI Text to follow the GameObject
        UpdateNameTextPosition();
    }

    void CreateNameText()
    {
        // Create a UI Text component dynamically under the existing canvas
        GameObject textObject = new GameObject("NameText");
        textObject.transform.SetParent(uiCanvas.transform); // Use the existing canvas
        nameText = textObject.AddComponent<Text>();
        nameText.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
        nameText.fontSize = 16;
        nameText.alignment = TextAnchor.MiddleCenter;
        nameText.color = Color.black;
    }

    void SetTextToGameObjectName()
    {
        // Set the text of the UI Text to the name of the GameObject
        if (nameText != null)
        {
            nameText.text = gameObject.name;
        }
    }

    void UpdateNameTextPosition()
    {
        // Update the position of the UI Text to follow the GameObject
        if (nameText != null)
        {
            // Set the UI Text position to be above the GameObject
            nameText.transform.position = Camera.main.WorldToScreenPoint(transform.position);
        }
    }
}