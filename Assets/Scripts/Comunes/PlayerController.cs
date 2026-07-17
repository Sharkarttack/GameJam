using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private  Animator playerAnimator;
    [SerializeField] private  AudioSource pasos;
    // Velocidad de movimiento del jugador (configurable desde el Inspector)
    [SerializeField] private float speed;
    // Referencia al Rigidbody2D del jugador para aplicar el movimiento
    [SerializeField] private Rigidbody2D rb;
    // Dirección de movimiento obtenida desde el Input System
    private Vector2 direction;
    // Referencia al objeto interactuable que está dentro del rango del jugador
    private InteractableObject interactableTarget;

    /// <summary>
    /// Se ejecuta a intervalos fijos, ideal para la física
    /// </summary>
    void FixedUpdate()
    {
        move();
    }

    /// <summary>
    /// Se llama automáticamente cuando el jugador mueve el joystick o las teclas
    /// </summary>
    /// <param name="context"></param>
    public void OnMove(InputAction.CallbackContext context)
    {
        // Lee la dirección de entrada (X,Y)
        direction = context.ReadValue<Vector2>();
        if (direction.y > 0)
        {
            playerAnimator.SetInteger("Direction", 1);
        }
        else if (direction.y < 0)
        {
            playerAnimator.SetInteger("Direction", -1);
        }
        else if (direction.x < 0)
        {
            playerAnimator.SetInteger("Direction", -2);
        }
        else if (direction.x > 0)
        {
            playerAnimator.SetInteger("Direction", 2);
        }
        if(context.canceled)
        {
            playerAnimator.SetInteger("Direction",0);
            pasos.Stop();
        }
        else if (!pasos.isPlaying)
        {
            pasos.Play();
        }
    }

    /// <summary>
    /// Aplica la velocidad al Rigidbody en función de la dirección
    /// </summary>
    private void move()
    {
        rb.linearVelocity = direction * speed;
    }

    /// <summary>
    /// Se llama cuando se pulsa el botón de interacción
    /// </summary>
    /// <param name="context"></param>
    public void OnInteract(InputAction.CallbackContext context)
    {
        // Solo ejecuta la interacción cuando comienza la pulsación
        if(context.started)
        {
            interact();
        }
    }

    /// <summary>
    /// Interactúa con el objeto si existe uno en el rango
    /// </summary>
    private void interact()
    {
        if (interactableTarget != null)
        {
            // Llama al método de interacción del objeto
            interactableTarget.OnInteract();
        }
        
    }

    /// <summary>
    /// Se ejecuta cuando el jugador entra en un Trigger
    /// </summary>
    /// <param name="collision"></param>
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
    /// Se ejecuta cuando el jugador sale de un Trigger
    /// </summary>
    /// <param name="collision"></param>
    void OnTriggerExit2D(Collider2D collision)
    {
        // Si el objeto del que sale era interactuable...
        if(collision.gameObject.GetComponent<InteractableObject>() is InteractableObject)
        {
            // Elimina la referencia para impedir la interacción
            interactableTarget = null;
        }
    }
}
