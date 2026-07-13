using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Controla el cursor del jugador en la escena 2. 
/// El objeto sigue la posición del ratón y permite interactuar 
/// con los objetos cuando se hace clic.
/// </summary>
public class CatchManagerEscena2 : MonoBehaviour
{
    // Rigidbody2D del cursor para moverlo mediante físicas
    [SerializeField] private Rigidbody2D rb;
    // Referencia al objeto interactuable que está bajo el cursor
    private InteractableObject interactableTarget;

    /// <summary>
    /// Se ejecuta a intervalos fijos, ideal para el movimiento del Rigidbody
    /// </summary>
    void FixedUpdate()
    {
        // Convierte la posición del ratón (pantalla) a coordenadas del mundo
        Vector2 newPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        // Mueve el Rigidbody hasta la posición del ratón
        rb.MovePosition(newPosition);
    }

    /// <summary>
    /// Se ejecuta cuando el jugador hace clic
    /// </summary>
    /// <param name="context"></param>
    public void OnMouseClick(InputAction.CallbackContext context)
    {
        // Si acaba de comenzar el clic y hay un objeto interactuable...
        if (context.started && interactableTarget != null)
        {
            // Ejecuta la interacción del objeto
            interactableTarget.OnInteract();
        }
    }
    
    // Se llama cuando el cursor entra en el Trigger de un objeto
    void OnTriggerEnter2D(Collider2D collision)
    {
        // Comprueba si el objeto tiene el componente InteractableObject
        if(collision.gameObject.GetComponent<InteractableObject>() is InteractableObject)
        {
            // Guarda la referencia para poder interactuar con él
            interactableTarget = collision.gameObject.GetComponent<InteractableObject>();
        }
    }

    /// <summary>
    /// Se llama cuando el cursor sale del Trigger de un objeto
    /// </summary>
    /// <param name="collision"></param>
    void OnTriggerExit2D(Collider2D collision)
    {
        // Si el objeto era interactuable...
        if(collision.gameObject.GetComponent<InteractableObject>() is InteractableObject)
        {
            // Elimina la referencia para impedir nuevas interacciones
            interactableTarget = null;
        }
    }
}
