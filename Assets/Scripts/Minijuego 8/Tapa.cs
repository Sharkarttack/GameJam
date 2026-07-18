using UnityEngine;
using UnityEngine.InputSystem;

public class Tapa : InteractableObject
{
    public Transform pos;
    [SerializeField] private Rigidbody2D rb;
    
    public override void OnInteract()
    {
        // Convierte la posición del ratón (pantalla) a coordenadas del mundo
        Vector2 newPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        // Mueve el Rigidbody hasta la posición del ratón
        rb.MovePosition(newPosition);
    }
    public void Posicionar()
    {
        transform.position = pos.position;
        transform.rotation = pos.rotation;
        gameObject.GetComponent<Collider2D>().enabled = false;
        transform.GetChild(0).gameObject.SetActive(false);
    }
}
