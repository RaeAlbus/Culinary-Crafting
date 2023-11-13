using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    private bool correct;
    public Text successText;
    public GameObject s;
    private Slot slotScript;

    // Start is called before the first frame update
    void Start()
    {
        slotScript = s.GetComponent<Slot>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void updateText(string t) {
        successText.text = t;
    }

    public void handleClick() {
        if (slotScript.ingredient != null) {
            updateText(slotScript.ingredient.name);
        } else {
            updateText("Fail");
        }
    }
}
