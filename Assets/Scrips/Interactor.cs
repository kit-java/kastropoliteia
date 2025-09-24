using UnityEngine;
using UnityEngine.UIElements;

public interface Interactable
{
    public void Interact();
    public void OnTrigger(bool activate);
}

public class Interactor : MonoBehaviour
{
    public KeyCode interactKey = KeyCode.E;
    private Interactable currentInteractable;

    void Update()
    {
        if (currentInteractable != null && Input.GetKeyDown(interactKey))
        {
            currentInteractable.Interact();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Interactable interactable = other.GetComponent<Interactable>();
        if (interactable != null)
        {
            currentInteractable = interactable;
            interactable.OnTrigger(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<Interactable>() == currentInteractable)
        {
            if (currentInteractable is Interactable) {
                currentInteractable.OnTrigger(false);
            }

            currentInteractable = null;
        }
    }
}
