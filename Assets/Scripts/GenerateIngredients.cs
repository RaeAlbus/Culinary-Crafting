using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateIngredients : MonoBehaviour
{
    public List<string> ing;
    public List<Sprite> iSprites;
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

        for (int i = 0; i < ing.Count; i++)
        {
            int col = i % objectsPerRow;
            int row = i / objectsPerRow;

            float x = col * spacing - ((objectsPerRow - 1) * spacing) / 2 + spawnOffset.x;
            float y = -row * spacing + spawnOffset.y;

            Vector3 spawnPosition = new Vector3(x, y + 3, 0f);
            GameObject spawnedObject = Instantiate(IngredientPrefab, spawnPosition, Quaternion.identity);
            spawnedObject.name = ing[i];

            // Find the corresponding sprite in the array based on the name
            Sprite sprite = iSprites.Find(s => s.name == spawnedObject.name);
            spawnedObject.GetComponent<SpriteRenderer>().sprite = sprite;
            float scaleFactor = 0.4f; // Adjust the scale factor as needed
            spawnedObject.transform.localScale = new Vector3(scaleFactor, scaleFactor, 1f);

        }
    }

    // Helper method to get the sprite for a specific ingredient
    private Sprite GetSpriteForIngredient(string ingredientName)
    {

        string spriteName = ingredientName.Replace(" ", "");
        return iSprites.Find(sprite => sprite.name == spriteName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
