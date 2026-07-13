using UnityEngine;
using UnityEngine.InputSystem;

public class InteractableBottle : InteractableObject
{
    [SerializeField] private Rigidbody2D rb;
    public override void OnInteract()
    {
        // Convierte la posición del ratón (pantalla) a coordenadas del mundo
        Vector2 newPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        // Mueve el Rigidbody hasta la posición del ratón
        rb.MovePosition(newPosition);
    }
}
