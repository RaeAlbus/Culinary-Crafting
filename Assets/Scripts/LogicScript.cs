using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;
using System;

public class LogicScript : MonoBehaviour
{
    public bool stepOneDone = false;
    public bool stepTwoDone = false;
    public Text successText;
    private GameObject[] slots;
    private List<string> goal1;
    private List<string> goal2;
    public GameObject IngredientPrefab;
    public Sprite[] dishSprites;

    // Start is called before the first frame update
    void Start()
    {
        //slots = GameObject.FindGameObjectsWithTag("Slot");
        goal1 = new List<string>{"Water", "Eggs", "Flour", "Sugar", "Bowl"};
        goal2 = new List<string>{"PancakeBatter", "FryingPan", "Stove"};
        goal1.Sort();
        goal2.Sort();
    }

    // Update is called once per frame
    void Update()
    {
        slots = GameObject.FindGameObjectsWithTag("Slot");

        if(stepOneDone && stepTwoDone){
            Invoke("NextLevel", 2.0f);
        }
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public void updateText(string t) {
        successText.text = t;
    }

    public void handleClick() {
        List<string> ingNames = new List<string>();
        foreach (GameObject slot in slots) {
            Slot slotScript = slot.GetComponent<Slot>();
            if (slotScript.ingredient != null) {
                ingNames.Add(slotScript.ingredient.name);
            }
        }
        ingNames.Sort();
    

        if(stepOneDone){
            if (goal2.SequenceEqual(ingNames)) {
                updateText("You made Pancakes!");
                stepTwoDone = true;
                
                // Resets all ingredients at top by calling SetUpIngredients in the GenerateIngredients Script
                GameObject generteSceneObject = GameObject.Find("GenerateIngredients");
                GenerateIngredients genIngScript = generteSceneObject.GetComponent<GenerateIngredients>();
                DestroyIngredients(genIngScript.ingredients);
                addIngredient("Pancakes");
                genIngScript.SetUpIngredients();

            } else {
                updateText("Not quite right...");
            }
        } else {
            if (goal1.SequenceEqual(ingNames)) {
                updateText("You made Pancake Batter!");
                stepOneDone = true;

                // Resets all ingredients at top by calling SetUpIngredients in the GenerateIngredients Script
                GameObject generteSceneObject = GameObject.Find("GenerateIngredients");
                GenerateIngredients genIngScript = generteSceneObject.GetComponent<GenerateIngredients>();
                DestroyIngredients(genIngScript.ingredients);
                addIngredient("PancakeBatter");
                genIngScript.SetUpIngredients();

                // Resets slot to be the new number of slots necessary
                GameObject generateSlotsObject = GameObject.Find("GenerateSlots");
                GenerateSlots generateSlotsScript = generateSlotsObject.GetComponent<GenerateSlots>();
                generateSlotsScript.DestroySlots();
                generateSlotsScript.numSlots = 3;
                generateSlotsScript.SetUpSlots();

            } else {
                updateText("Not quite right...");
            }
        }
    }

    public void DestroyIngredients(string[] ingNames) {
        foreach (string name in ingNames) {
            GameObject objectToDestroy = GameObject.Find(name);

            if (objectToDestroy != null) {
                Destroy(objectToDestroy);
            } else {
                Debug.LogWarning("GameObject with name " + name + " not found.");
            }
        }
    }

    public void addIngredient(string name){
        GameObject generteSceneObject = GameObject.Find("GenerateIngredients");
        GenerateIngredients genIngScript = generteSceneObject.GetComponent<GenerateIngredients>();
        // Create a new array with a larger size
        string[] newIngredients = new string[ genIngScript.ingredients.Length + 1];
        // Copy existing elements to the new array
        for (int i = 0; i <  genIngScript.ingredients.Length; i++)
        {
            newIngredients[i] = genIngScript.ingredients[i];
        }
        // Add the new ingredient to the end of the new array
        newIngredients[newIngredients.Length - 1] = name;
        // Update the original array reference
        genIngScript.ingredients = newIngredients;
    }

    public void NewItemPopup(string name) {



    }

    // Helper method to get the sprite for a specific ingredient
    private Sprite GetSpriteForIngredient(string ingredientName)
    {
        string spriteName = ingredientName.Replace(" ", "");
        return System.Array.Find(dishSprites, sprite => sprite.name == spriteName);
    }
}
