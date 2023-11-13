using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateIngredients : MonoBehaviour
{
    private string[] ingredients;
    public GameObject IngredientPrefab;
    // Start is called before the first frame update
    void Start()
    {
        float index = 0.0f;
        ingredients = new string[]{"Water", "Sugar", "Flour", "Oil", "Eggs", "Salt", "Pepper", "Bread", "Turkey", "Cheese", "Lettuce", "Bowl", "Stove", "Pan", "Pot", "Knife"};
        foreach (string name in ingredients) {
            GameObject spawnedPrefab = Instantiate(IngredientPrefab, transform.position + Vector3.right * index * 1.5f, transform.rotation);
            spawnedPrefab.name = name;
            index += 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
