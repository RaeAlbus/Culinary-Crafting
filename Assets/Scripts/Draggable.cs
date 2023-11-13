using UnityEngine;

public class Draggable : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private GameObject[] slots;

    void Start() {
        slots = GameObject.FindGameObjectsWithTag("Slot");
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
        if (isDragging)
        {
            Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, offset.z);
            Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint);
            transform.position = cursorPosition;
        }
    }
}