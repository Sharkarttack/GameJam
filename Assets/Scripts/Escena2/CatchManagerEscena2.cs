using UnityEngine;
using UnityEngine.InputSystem;

public class CatchManagerEscena2 : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    private InteractableObject interactableTarget;

    void FixedUpdate()
    {
        Vector2 newPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        rb.MovePosition(newPosition);
    }

    public void OnMouseClick(InputAction.CallbackContext context)
    {
        if (context.started && interactableTarget != null)
        {
            interactableTarget.OnInteract();
        }
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<InteractableObject>() is InteractableObject)
        {
            interactableTarget = collision.gameObject.GetComponent<InteractableObject>();
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<InteractableObject>() is InteractableObject)
        {
            interactableTarget = null;
        }
    }
}
