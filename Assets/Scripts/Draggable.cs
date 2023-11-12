using UnityEngine;

public class Draggable : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private Transform slotTransform;
    public GameObject slot;

    void Start() {
        slotTransform = slot.transform;
    }

    void OnMouseDown()
    {
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        isDragging = true;
    }

    void OnMouseUp()
    {
        isDragging = false;

        // Check if the draggable is close enough to the slot
        if (Vector2.Distance(transform.position, slotTransform.position) < 1.0f)
        {
            // Snap the draggable to the slot
            transform.position = slotTransform.position;
        }
    }

    void Update()
    {
        if (isDragging)
        {
            Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, offset.z);
            Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint);
            transform.position = cursorPosition;
        }
    }
}