using UnityEngine;

public class Slot : MonoBehaviour
{
    // You can adjust this distance based on your game's requirements
    public float thresholdDistance;
    public bool success;
    public GameObject ingredient;

    void Start() {
        success = false;
        thresholdDistance = 1.0f;
        ingredient = null;
    }

    public void mUp(GameObject food)
    {
        // Check if the dragged object entered the slot
        if (food.CompareTag("Draggable"))
        {
            Draggable draggable = food.GetComponent<Draggable>();

            // Check if the draggable is close enough to lock into place
            if (Vector2.Distance(draggable.transform.position, transform.position) < thresholdDistance)
            {
                // Snap the draggable to the slot
                draggable.transform.position = transform.position;
                Debug.Log("Locked");
                success = true;
                ingredient = food;
            } else {
                Debug.Log("Unlocked");
                success = false;
                ingredient = null;
            }
        }
    }

    // void OnTriggerExit2D(Collider2D other) {
    //     if (other.CompareTag("Draggable"))
    //     {
    //         success = false;
    //     }
    //     Debug.Log("Exit");
    // }

    void Update() {

    }
}

