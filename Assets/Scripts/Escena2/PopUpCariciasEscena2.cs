using UnityEngine;

/// <summary>
/// Objeto interactuable del pop-up de caricias. 
/// Cada interacción cuenta como una caricia para el minijuego.
/// </summary>
public class PopUpCariciasEscena2 : InteractableObject
{
    // Referencia al gestor del minijuego de caricias
    [SerializeField] private CariciasManagerEscena2 cariciasManager;

    /// <summary>
    /// Se ejecuta cuando el jugador interactúa con el pop-up
    /// </summary>
    public override void OnInteract()
    {
        // Notifica al gestor que se ha realizado una caricia
        cariciasManager.hacerMimos();
    }
}
