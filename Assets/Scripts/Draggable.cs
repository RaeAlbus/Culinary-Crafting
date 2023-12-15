using UnityEngine;

public class Draggable : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private GameObject[] slots;
    private float minX, minY, maxX, maxY;

    void Start() {
        SetBoundaries();
    }

     void SetBoundaries()
    {
        // Get the screen boundaries in world coordinates
        Vector3 minWorld = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        Vector3 maxWorld = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        // Calculate boundaries for the draggable object
        float objectWidth = GetComponent<Renderer>().bounds.extents.x;
        float objectHeight = GetComponent<Renderer>().bounds.extents.y;

        minX = minWorld.x + objectWidth;
        minY = minWorld.y + objectHeight;
        maxX = maxWorld.x - objectWidth;
        maxY = maxWorld.y - objectHeight;
    }

    void OnMouseDown()
    {
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        isDragging = true;
    }

    void OnMouseUp()
    {
        isDragging = false;
        foreach (GameObject slot in slots) {
            Slot slotScript = slot.GetComponent<Slot>();
            slotScript.mUp(gameObject);
        }
        
    }

    void Update()
    {
        slots = GameObject.FindGameObjectsWithTag("Slot");
        
        if (isDragging)
        {
            Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, offset.z);
            Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint);

            // Clamp the cursor position within the boundaries
            cursorPosition.x = Mathf.Clamp(cursorPosition.x, minX, maxX);
            cursorPosition.y = Mathf.Clamp(cursorPosition.y, minY, maxY);

            transform.position = cursorPosition;
        }
    }
}