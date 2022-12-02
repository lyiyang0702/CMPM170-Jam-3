using UnityEngine;

public class Interactable : MonoBehaviour
{
    public virtual void Interact()
    {
        // This method is meant to be override
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Interact();
    }
}
