using UnityEngine;

public class Slot : MonoBehaviour
{
    public float thresholdDistance;
    public GameObject ingredient;
    private AudioSource audioSource;
    public AudioClip lockInSound;

    void Start()
    {
        thresholdDistance = 1.0f;
        ingredient = null;
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.clip = lockInSound;
    }

    // Snaps any nearby ingredient to a slot if slot is empty
    public void mUp(GameObject food)
    {
        if (food.CompareTag("Draggable"))
        {
            Draggable draggable = food.GetComponent<Draggable>();

            if (Vector2.Distance(draggable.transform.position, transform.position) < thresholdDistance)
            {
                // Only snap if the slot is empty
                if (ingredient == null || ingredient == food)
                {
                    draggable.transform.position = transform.position;
                    ingredient = food;
                    if (audioSource != null && lockInSound != null)
                    {
                        audioSource.Play();
                    }
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

}