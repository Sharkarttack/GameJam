using UnityEngine;
using UnityEngine.InputSystem;

/// <summary> 
/// Implementa el comportamiento interactuable del biberón. 
/// Permite que el jugador arrastre el objeto siguiendo la posición 
/// del ratón mientras permanece seleccionado. 
/// </summary>
public class InteractableBottle : InteractableObject
{
    /// <summary> 
    /// Rigidbody2D asociado al biberón. 
    /// Se utiliza para desplazar el objeto mediante el sistema de físicas. 
    /// </summary>
    [SerializeField] private Rigidbody2D rb;

    /// <summary> 
    /// Se ejecuta mientras el jugador interactúa con el biberón. 
    /// Convierte la posición actual del cursor desde coordenadas de 
    /// pantalla a coordenadas del mundo y desplaza el objeto hasta 
    /// dicha posición. 
    /// </summary>
    public override void OnInteract()
    {
        // Convierte la posición del ratón (pantalla) a coordenadas del mundo
        Vector2 newPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        // Mueve el Rigidbody hasta la posición del ratón
        rb.MovePosition(newPosition);
    }
}
