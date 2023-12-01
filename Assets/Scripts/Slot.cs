using UnityEngine;

public class Slot : MonoBehaviour
{
    public float thresholdDistance;
    public GameObject ingredient;

    void Start()
    {
        thresholdDistance = 1.0f;
        ingredient = null;
    }

    public void mUp(GameObject food)
    {
        if (food.CompareTag("Draggable"))
        {
            Draggable draggable = food.GetComponent<Draggable>();

            if (Vector2.Distance(draggable.transform.position, transform.position) < thresholdDistance)
            {
                // Only snap if the slot is empty
                if (ingredient == null)
                {
                    draggable.transform.position = transform.position;
                    ingredient = food;
                }
            }
        }
        Debug.Log(ingredient);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Draggable") && other.gameObject == ingredient)
        {
            ingredient = null;
        }
    }

    void Update()
    {
        // Additional logic can go here if needed
    }
}