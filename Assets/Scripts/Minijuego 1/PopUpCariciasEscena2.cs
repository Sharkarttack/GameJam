using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Objeto interactuable del pop-up de caricias. 
/// Cada interacción cuenta como una caricia para el minijuego.
/// </summary>
public class PopUpCariciasEscena2 : InteractableObject
{
    // Referencia al gestor del minijuego de caricias
    [SerializeField] private CariciasManagerEscena2 cariciasManager;
    [SerializeField] private ParticleSystem corazones;
    public float goalSpeed;
    private Vector2 lastMousePos;
    void Update()
    {
        if(Mouse.current.leftButton.IsPressed() && isShaking())
        {
            
            corazones.Play();
            cariciasManager.hacerMimos();
        }
        else
        {
            corazones.Stop();
        }
    }
    
    ///<summary>
    /// Se ejecuta cuando el jugador interactúa con el pop-up
    /// </summary>
    public override void OnInteract()
    {
        // Notifica al gestor que se ha realizado una caricia
        //cariciasManager.hacerMimos();
    }
    private bool isShaking()
    {
        // Posición actual del ratón.
        Vector2 currentPos = Mouse.current.position.ReadValue();
        // Calcula la velocidad del ratón en píxeles por segundo.
        float speed = (currentPos - lastMousePos).magnitude / Time.deltaTime;
        lastMousePos = currentPos;
        // Comprueba si la velocidad supera el umbral.
        if (speed > goalSpeed)
        {
            return true;
        }
        return false;
    }
}
