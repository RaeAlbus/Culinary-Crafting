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
    public GameObject introBlur;
    private int currentIndex = 0;
    private bool introPanelActive = true;

    void Start()
    {
        ShowNext();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (introPanelActive)
            {
                // If intro panel is active, proceeds to the next message
                introPanelActive = false;
                ShowNext();
            }
            else
            {
                // If there are more messages, shows the next one
                if (currentIndex < tutorialMessages.Length - 1)
                {
                    currentIndex++;
                    ShowNext();
                }
                else
                {
                    LoadNextScene();
                }
            }
        }
    }

    void ShowNext()
    {
        if (introPanelActive)
        {
            // Shows the introductory panel
            introPanel.SetActive(true);
            introBlur.SetActive(true);
        }
        else
        {
            // Hides the introductory panel
            introPanel.SetActive(false);
            introBlur.SetActive(false);

            // Displays the current tutorial message and sets its position
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