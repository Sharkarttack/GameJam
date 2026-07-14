using UnityEngine;
using UnityEngine.InputSystem;

public class Esquina : InteractableObject
{
    public enum Esquinas { UpLeft, UpRight, DownLeft, DownRight }
    public Esquinas esquina;
    /// <summary> 
    /// Rigidbody2D asociado al biberón. 
    /// Se utiliza para desplazar el objeto mediante el sistema de físicas. 
    /// </summary>
    [SerializeField] private Rigidbody2D rb;

    public override void OnInteract()
    {
        // Convierte la posición del ratón (pantalla) a coordenadas del mundo
        Vector2 newPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        // Mueve el Rigidbody hasta la posición del ratón
        rb.MovePosition(newPosition);
    }
}
