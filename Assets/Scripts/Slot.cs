using UnityEngine;

public class Slot : MonoBehaviour
{
    // You can adjust this distance based on your game's requirements
    public float thresholdDistance;
    public GameObject ingredient;

    void Start() {
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
                ingredient = food;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Draggable"))
        {
            ingredient = null;
        }
    }

    void Update() {

    }
}

