using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngredientText : MonoBehaviour
{
    public Transform completetionText;

    void Start() {
        GetComponent<Text>().text = completetionText.gameObject.name;
    }

    void Update()
    {
        if (completetionText != null)
        {
            transform.position = Camera.main.WorldToScreenPoint(completetionText.position);
        }
    }
}
