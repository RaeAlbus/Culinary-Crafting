using UnityEngine;

public class Draggable : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private Transform slotTransform;
    public GameObject slot;
    private Slot slotScript;

    void Start() {
        slotTransform = slot.transform;
        slotScript = slot.GetComponent<Slot>();
    }

    void OnMouseDown()
    {
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        isDragging = true;
    }

    void OnMouseUp()
    {
        isDragging = false;
        slotScript.mUp(gameObject);
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