using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;
using System;

public class LogicScript : MonoBehaviour
{
    public Text successText;
    private GameObject[] slots;
    public List<(List<string>, string)> allGoals;
    public GameObject IngredientPrefab;
    public List<Sprite> dishSprites;
    public PopupManager popupManager;
    private AudioSource failAudioSource;
    public AudioClip failSound;
    private AudioSource successAudioSource;
    public AudioClip successSound;

    // Start is called before the first frame update
    void Start()
    {
        failAudioSource = gameObject.AddComponent<AudioSource>();
        failAudioSource.playOnAwake = false;
        failAudioSource.clip = failSound;
        successAudioSource = gameObject.AddComponent<AudioSource>();
        successAudioSource.playOnAwake = false;
        successAudioSource.clip = successSound;
    }

    // Update is called once per frame
    void Update()
    {
        slots = GameObject.FindGameObjectsWithTag("Slot");

        if(allGoals.Count == 0){
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

        if (allGoals.Count == 1) {
            if (allGoals[0].Item1.SequenceEqual(ingNames)) {
                updateText("You did it!");
                successAudioSource.Play();

                Sprite targetSprite = FindSpriteByName(allGoals[0].Item2.Replace(" ", ""));
                popupManager.ShowPopup("You made " + allGoals[0].Item2 + "!", targetSprite);
                
                // Resets all ingredients at top by calling SetUpIngredients in the GenerateIngredients Script
                GameObject generateSceneObject = GameObject.Find("GenerateIngredients");
                GenerateIngredients genIngScript = generateSceneObject.GetComponent<GenerateIngredients>();
                DestroyIngredients(genIngScript.ing);
                addIngredient(allGoals[0].Item2.Replace(" ", ""));
                genIngScript.SetUpIngredients();
                allGoals.RemoveAt(0);
            } else {
                updateText("Not quite right...");
                failAudioSource.Play();
            }
        } else {
            if (allGoals[0].Item1.SequenceEqual(ingNames)) {
                updateText("Now whats the next step?");
                successAudioSource.Play();

                // Resets all ingredients at top by calling SetUpIngredients in the GenerateIngredients Script
                GameObject generateSceneObject = GameObject.Find("GenerateIngredients");
                GenerateIngredients genIngScript = generateSceneObject.GetComponent<GenerateIngredients>();
                DestroyIngredients(genIngScript.ing);
                addIngredient(allGoals[0].Item2.Replace(" ", ""));
                genIngScript.SetUpIngredients();

                Sprite targetSprite = FindSpriteByName(allGoals[0].Item2.Replace(" ", ""));
                popupManager.ShowPopup("You made " + allGoals[0].Item2 + "!", targetSprite);

                // Resets slot to be the new number of slots necessary
                GameObject generateSlotsObject = GameObject.Find("GenerateSlots");
                GenerateSlots generateSlotsScript = generateSlotsObject.GetComponent<GenerateSlots>();
                generateSlotsScript.DestroySlots();
                generateSlotsScript.numSlots = allGoals[1].Item1.Count;
                generateSlotsScript.SetUpSlots();
                allGoals.RemoveAt(0);

            } else {
                int correctCount = 0;
                List<string> commonElements = allGoals[0].Item1.Intersect(ingNames).ToList();
                correctCount = commonElements.Count;
                int totalSlots = allGoals[0].Item1.Count;
                
                updateText("Not quite right..." + correctCount + " out of " + totalSlots + " correct");
                failAudioSource.Play();
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

    public void addIngredient(string name){
        GameObject generateSceneObject = GameObject.Find("GenerateIngredients");
        GenerateIngredients genIngScript = generateSceneObject.GetComponent<GenerateIngredients>();
        genIngScript.ing.Add(name);
    }

    public void NewItemPopup(string name) {



    }

    public Sprite FindSpriteByName(string spriteName)
    {
        Sprite foundSprite = dishSprites.Find(sprite => sprite.name == spriteName);
        return foundSprite;
    }
}

