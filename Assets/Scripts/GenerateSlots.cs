using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateSlots : MonoBehaviour
{

    public GameObject SlotPrefab;
    public int numSlots;

    public void SetUpSlots(){
        for(int i = 0; i < numSlots; i++){
            float xPos = transform.position.x - (i * (2.0f + 0.5f)) + ((numSlots - 1) * (2.0f + 0.5f)) / 2.0f;
            GameObject spawnedPrefab = Instantiate(SlotPrefab, new Vector3(xPos, transform.position.y), transform.rotation);
        }
    }

    public void DestroySlots(){
        // Finds all slots
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Slot");

        // Iterate through each slot and destroy it
        foreach (GameObject obj in objectsWithTag)
        {
            Destroy(obj);
        }
    }
    
}
