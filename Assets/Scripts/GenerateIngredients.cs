using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateIngredients : MonoBehaviour
{
    public string[] ingredients = new string[]{"Water", "Sugar", "Flour", "Oil", "Eggs", "Salt", "Pepper", "Bread", "Turkey", "Cheese", "Lettuce", "Bowl", "Stove", "Frying Pan"};
    public Sprite[] ingredientSprites;
    public GameObject IngredientPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        SetUpIngredients();
    }

    public void SetUpIngredients(){

        int objectsPerRow = 8;
        float spacing = 2.0f;
        Vector2 spawnOffset = new Vector2(0f, 0f);

        for (int i = 0; i < ingredients.Length; i++)
        {
            int col = i % objectsPerRow;
            int row = i / objectsPerRow;

            float x = col * spacing - ((objectsPerRow - 1) * spacing) / 2 + spawnOffset.x;
            float y = -row * spacing + spawnOffset.y;

            Vector3 spawnPosition = new Vector3(x, y + 3, 0f);
            GameObject spawnedObject = Instantiate(IngredientPrefab, spawnPosition, Quaternion.identity);
            spawnedObject.name = ingredients[i];

            // Find the corresponding sprite in the array based on the name
            Sprite sprite = System.Array.Find(ingredientSprites, s => s.name == spawnedObject.name);
            spawnedObject.GetComponent<SpriteRenderer>().sprite = sprite;
            float scaleFactor = 0.4f; // Adjust the scale factor as needed
            spawnedObject.transform.localScale = new Vector3(scaleFactor, scaleFactor, 1f);

        }
        /*float currRow = 0;
        int numObjs = 1;
        float index = 0.0f;
        foreach (string name in ingredients) {
            GameObject spawnedPrefab = Instantiate(IngredientPrefab, new Vector3(transform.position.x + index * 2f, transform.position.y - currRow), transform.rotation);
            spawnedPrefab.name = name;

            // Attaches sprite to GameObject
            Sprite sprite = GetSpriteForIngredient(name);
            SpriteRenderer spriteRenderer = spawnedPrefab.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = sprite;
            float scaleFactor = 0.4f; // Adjust the scale factor as needed
            spawnedPrefab.transform.localScale = new Vector3(scaleFactor, scaleFactor, 1f);

            index += 1;
            numObjs += 1;
            if((numObjs != 1 && 11 % numObjs == 0) || (11 % numObjs == 0)){
                currRow += 1.95f;
                index = 0.0f;
            }
        }*/
    }

    // Helper method to get the sprite for a specific ingredient
    private Sprite GetSpriteForIngredient(string ingredientName)
    {

        string spriteName = ingredientName.Replace(" ", "");
        return System.Array.Find(ingredientSprites, sprite => sprite.name == spriteName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
