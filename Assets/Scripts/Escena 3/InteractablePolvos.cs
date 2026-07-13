using UnityEngine;
using UnityEngine.InputSystem;

public class InteractablePolvos : InteractableObject
{
    [SerializeField] private Rigidbody2D rb;
    public override void OnInteract()
    {
        // Convierte la posición del ratón (pantalla) a coordenadas del mundo
        Vector2 newPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        // Mueve el Rigidbody hasta la posición del ratón
        rb.MovePosition(newPosition);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isSelected && other.gameObject.GetComponent<BottleState>() is BottleState)
        {
            other.gameObject.GetComponent<BottleState>().polvos = true;
        }
    }
    
}
