
using UnityEngine.SceneManagement;

/// <summary>
/// Clase que representa una cama interactuable.
/// Hereda de InteractableObject para poder ser utilizada por el PlayerController.
/// </summary>
public class CamaEscena1 : InteractableObject
{
    /// <summary>
    /// Sobrescribe el método de interacción definido en la clase base.
    /// </summary>
    public override void OnInteract()
    {
        // Carga la escena llamada "Escena 2".
        SceneManager.LoadScene("Escena 2");
    }
}
