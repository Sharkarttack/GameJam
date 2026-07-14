using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractablePanal : InteractableObject
{
    [SerializeField] private string nextScene;
    int numDesatados = 0;
    int numAtados = 0;
    public enum TipoPañal { Nuevo, Antiguo }
    public TipoPañal tipoPañal;
    public bool colocado;
    [SerializeField] private Rigidbody2D rb;
    public override void OnInteract()
    {
        // Convierte la posición del ratón (pantalla) a coordenadas del mundo
        Vector2 newPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        // Mueve el Rigidbody hasta la posición del ratón
        rb.MovePosition(newPosition);
    }
    public IEnumerator Desatar()
    {
        numDesatados++;
        if (numDesatados >= 2)
        {
            yield return new WaitForSeconds(0.1f);
            gameObject.GetComponent<Collider2D>().enabled = true;
        }
    }
    public void Atar()
    {
        numAtados++;
        if (numAtados >= 2)
        {
            print("Ended mimigame");
        }
    }
}
