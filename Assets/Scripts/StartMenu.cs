using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManger.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
