using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class LogicScript : MonoBehaviour
{
    private bool correct;
    public Text successText;
    private GameObject[] slots;
    private List<string> goal;

    // Start is called before the first frame update
    void Start()
    {
        slots = GameObject.FindGameObjectsWithTag("Slot");
        goal = new List<string>{"Pasta", "Sauce"};
        goal.Sort();
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
        } else {
            updateText("Fail");
        }


    }
}
