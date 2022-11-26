using UnityEngine;

public class Interactable : MonoBehaviour
{
    public virtual void Interact()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Interact();
    }
}
