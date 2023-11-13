using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public bool stepOneDone = false;
    public bool stepTwoDone = false;
    public Text successText;
    private GameObject[] slots;
    private List<string> goal;
    private List<string> goal2;
    public GameObject IngredientPrefab;
    public Sprite[] dishSprites;
    public GenerateIngredients scriptAReference;

    // Start is called before the first frame update
    void Start()
    {
        slots = GameObject.FindGameObjectsWithTag("Slot");
        goal = new List<string>{"Water", "Eggs", "Flour", "Sugar", "Bowl"};
        goal2 = new List<string>{"Pancake Batter", "Frying Pan", "Stove"};
        goal.Sort();
        goal2.Sort();
    }

    // Update is called once per frame
    void Update()
    {
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
                spawnIngredient("Pancakes");
                stepTwoDone = true;
            } else {
                updateText("Not quite right...");
            }
        } else {
            if (goal.SequenceEqual(ingNames)) {
                updateText("You made Pancake Batter!");
                spawnIngredient("Pancake Batter");
                stepOneDone = true;

                // Resets all ingredients at top by calling SetUpIngredients in the GenerateIngredients Script
                GameObject generteSceneObject = GameObject.Find("GenerateScene");
                GenerateIngredients genIngScript = generteSceneObject.GetComponent<GenerateIngredients>();
                genIngScript.SetUpIngredients();
                DestroyIngredients(ingNames);
            } else {
                updateText("Not quite right...");
            }
        }
    }

    public void DestroyIngredients(List<string> ingNames) {
        foreach (string name in ingNames) {
            GameObject objectToDestroy = GameObject.Find(name);

            if (objectToDestroy != null) {
                Destroy(objectToDestroy);
            } else {
                Debug.LogWarning("GameObject with name " + name + " not found.");
            }
        }
    }

    public void spawnIngredient(string name) {
        GameObject spawnedPrefab = Instantiate(IngredientPrefab, transform.position, transform.rotation);
        spawnedPrefab.name = name;

        // Attaches sprite to GameObject
        Sprite sprite = GetSpriteForIngredient(name);
        SpriteRenderer spriteRenderer = spawnedPrefab.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprite;
        float scaleFactor = 0.4f; // Adjust the scale factor as needed
        spawnedPrefab.transform.localScale = new Vector3(scaleFactor, scaleFactor, 1f);
    }

    // Helper method to get the sprite for a specific ingredient
    private Sprite GetSpriteForIngredient(string ingredientName)
    {
        string spriteName = ingredientName.Replace(" ", "");
        return System.Array.Find(dishSprites, sprite => sprite.name == spriteName);
    }
}
