using UnityEngine;
using UnityEngine.InputSystem;

/// <summary> 
/// Implementa el comportamiento interactuable del recipiente de polvos. 
/// Permite arrastrar el objeto con el ratón y añadir los polvos al 
/// biberón cuando entra en contacto con él durante la interacción. 
/// </summary>
public class InteractablePolvos : InteractableObject
{
    /// <summary> 
    /// Rigidbody2D asociado al recipiente de polvos. 
    /// Se utiliza para desplazar el objeto mediante el sistema de físicas. 
    /// </summary>
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Sprite sprite;

    /// <summary> 
    /// Se ejecuta mientras el jugador interactúa con el recipiente. 
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

    /// <summary> 
    /// Se ejecuta cuando el recipiente entra en contacto con otro objeto. 
    /// Si el recipiente está siendo sujetado por el jugador y el objeto 
    /// con el que colisiona es un biberón, se marca que los polvos han 
    /// sido añadidos. 
    /// </summary> 
    /// <param name="other"> 
    /// Collider del objeto con el que se ha producido la colisión. 
    /// </param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if (isSelected && other.gameObject.GetComponent<BottleState>() is BottleState)
        {
            other.gameObject.GetComponent<BottleState>().polvos = true;
            other.gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
        }
    }

}
