using UnityEngine;

public class Slot : MonoBehaviour
{
    // You can adjust this distance based on your game's requirements
    public float thresholdDistance = 1.0f;

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the dragged object entered the slot
        if (other.CompareTag("Draggable"))
        {
            Draggable draggable = other.GetComponent<Draggable>();

            // Check if the draggable is close enough to lock into place
            if (Vector2.Distance(draggable.transform.position, transform.position) < thresholdDistance)
            {
                // Snap the draggable to the slot
                draggable.transform.position = transform.position;
            }
        }
    }
}

