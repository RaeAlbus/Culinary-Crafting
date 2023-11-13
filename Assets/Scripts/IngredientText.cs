using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngredientText : MonoBehaviour
{
    public Transform targetObject; // Assign the GameObject to follow in the Inspector

    void Start() {
        GetComponent<Text>().text = targetObject.gameObject.name;
    }

    void Update()
    {
        if (targetObject != null)
        {
            // Update the position of the Text object to match the target GameObject
            transform.position = Camera.main.WorldToScreenPoint(targetObject.position);
        }
    }
}
