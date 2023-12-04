using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class SceneSpecificScript : MonoBehaviour
{
    public LogicScript logicScript;
    public GenerateIngredients generateIngredients;
    public List<Sprite> level1Sprites;
    public GenerateSlots generateSlots;

    void Start()
    {
        logicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        generateIngredients = GameObject.FindGameObjectWithTag("GenIngredients").GetComponent<GenerateIngredients>();
        generateSlots = GameObject.FindGameObjectWithTag("GenSlots").GetComponent<GenerateSlots>();
        // Get the current scene name
        string currentScene = SceneManager.GetActiveScene().name;

        // Perform actions based on the scene name
        switch (currentScene)
        {
            case "LevelOneBreakfast":
                DoScene1Actions();
                break;
            case "LevelOneLunch":
                DoScene2Actions();
                break;
            // Add more cases for additional scenes as needed
            default:
                Debug.LogWarning("Unknown scene: " + currentScene);
                break;
        }
    }

    void DoScene1Actions()
    {
        logicScript.allGoals = new List<(List<string>, string)>();
        logicScript.allGoals.Add((new List<string>{"Water", "Eggs", "Flour", "Sugar", "Bowl"}, "Pancake Batter"));
        logicScript.allGoals.Add((new List<string>{"PancakeBatter", "FryingPan", "Stove"}, "Pancakes"));
        foreach ((List<string>, string) ing in logicScript.allGoals) {
            ing.Item1.Sort();
        }
        generateIngredients.ing = new List<string>{"Water", "Sugar", "Flour", "Oil", "Eggs", "Salt", "Pepper", "Bread", "Turkey", "Cheese", "Lettuce", "Bowl", "Stove", "FryingPan"};
        generateIngredients.iSprites = level1Sprites;
        generateSlots.numSlots = logicScript.allGoals[0].Item1.Count;
        generateIngredients.SetUpIngredients();
        generateSlots.SetUpSlots();
        logicScript.dishSprites = level1Sprites;
        Debug.Log("Performing actions for Scene1");
    }

    void DoScene2Actions()
    {
        logicScript.allGoals = new List<(List<string>, string)>();
        logicScript.allGoals.Add((new List<string>{"Oil", "Salt", "Pepper", "Bowl"}, "Dressing"));
        logicScript.allGoals.Add((new List<string>{"Lettuce", "Dressing", "Bowl"}, "Salad w Dressing"));
        foreach ((List<string>, string) ing in logicScript.allGoals) {
            ing.Item1.Sort();
        }
        generateIngredients.ing = new List<string>{"Water", "Sugar", "Flour", "Oil", "Eggs", "Salt", "Pepper", "Bread", "Turkey", "Cheese", "Lettuce", "Bowl", "Stove", "FryingPan"};
        generateIngredients.iSprites = level1Sprites;
        generateSlots.numSlots = logicScript.allGoals[0].Item1.Count;
        generateIngredients.SetUpIngredients();
        generateSlots.SetUpSlots();
        logicScript.dishSprites = level1Sprites;
        Debug.Log("Performing actions for Scene2");
    }
}