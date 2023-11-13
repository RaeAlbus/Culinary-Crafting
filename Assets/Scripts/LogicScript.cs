using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    private bool correct;
    public Text successText;
    private GameObject[] slots;
    private List<string> goal;
    private List<string> goal2;
    public GameObject IngredientPrefab;

    // Start is called before the first frame update
    void Start()
    {
        slots = GameObject.FindGameObjectsWithTag("Slot");
        goal = new List<string>{"Water", "Eggs", "Flour", "Sugar", "Bowl"};
        goal2 = new List<string>{"Pancake Batter", "Pan", "Stove"};
        goal.Sort();
        goal2.Sort();
    }

    // Update is called once per frame
    void Update()
    {

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
                Debug.Log(slotScript.ingredient.name);
            }
        }
        ingNames.Sort();
        if (goal.SequenceEqual(ingNames)) {
            updateText("Success");
            spawnIngredient("Pancake Batter");
        } else if (goal2.SequenceEqual(ingNames)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        } else {
            updateText("Fail");
        }
    }

    public void spawnIngredient(string name) {
        GameObject spawnedPrefab = Instantiate(IngredientPrefab, transform.position, transform.rotation);
        spawnedPrefab.name = name;
    }
}
