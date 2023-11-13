using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public LogicScript logic;

    void Start() {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }
}