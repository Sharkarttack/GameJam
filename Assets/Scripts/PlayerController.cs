using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;
    private Vector2 direction;
    private InteractableObject interactableTarget;
    void FixedUpdate()
    {
        move();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        direction = context.ReadValue<Vector2>();
    }

    private void move()
    {
        rb.linearVelocity = direction * speed;
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            interact();
        }
    }

    private void interact()
    {
        if (interactableTarget != null)
        {
            print("E");
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
