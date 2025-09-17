using UnityEngine;
using UnityEngine.UIElements;

public interface Interactable
{
    public void Interact();
    public string interactionText();
    public void toggleE(bool activate);
}

public class Interactor : MonoBehaviour
{
    public KeyCode interactKey = KeyCode.E;
    public TextElement interactionPrompt;

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
            interactable.toggleE(true);
            if (interactionPrompt != null)
                interactionPrompt.text = interactable.interactionText();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<Interactable>() == currentInteractable)
        {
            if (currentInteractable is Interactable) {
                currentInteractable.toggleE(false);
            }

            currentInteractable = null;
            if (interactionPrompt != null)
                interactionPrompt.text = "test";
        }
    }
}
