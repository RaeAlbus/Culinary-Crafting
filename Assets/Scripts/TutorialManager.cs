using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    [System.Serializable]
    public class TutorialMessage
    {
        public string message;
        public Vector2 position;
    }

    public Text tutorialText;
    public TutorialMessage[] tutorialMessages;
    public GameObject introPanel;
    public GameObject panelBackground;
    private int currentIndex = 0; // Start at -1 to show the intro panel first
    private bool introPanelActive = true;

    void Start()
    {
        ShowNext();
    }

    void Update()
    {
        // Check for mouse click
        if (Input.GetMouseButtonDown(0))
        {
            if (introPanelActive)
            {
                // If intro panel is active, proceed to the next message
                introPanelActive = false;
                ShowNext();
            }
            else
            {
                // If there are more messages, show the next one
                if (currentIndex < tutorialMessages.Length - 1)
                {
                    currentIndex++;
                    ShowNext();
                }
                else
                {
                    // End of tutorial, load the next scene
                    LoadNextScene();
                }
            }
        }
    }

    void ShowNext()
    {
        if (introPanelActive)
        {
            // Show the introductory panel
            introPanel.SetActive(true);
        }
        else
        {
            // Hide the introductory panel
            introPanel.SetActive(false);

            // Display the current tutorial message and set its position
            tutorialText.text = tutorialMessages[currentIndex].message;
            tutorialText.rectTransform.anchoredPosition = tutorialMessages[currentIndex].position;
            RectTransform panelRectTransform = panelBackground.GetComponent<RectTransform>();
            panelRectTransform.anchoredPosition = tutorialText.rectTransform.anchoredPosition;

        }
    }

    void LoadNextScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


}