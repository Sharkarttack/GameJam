
using UnityEngine;
using UnityEngine.InputSystem;

public class IntrusiveThougth : InteractableObject
{
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
    public void Posicionar(Transform newTransform)
    {
        transform.position = newTransform.position;
        transform.rotation = newTransform.rotation;
        transform.GetChild(0).gameObject.SetActive(false);
    }
}
