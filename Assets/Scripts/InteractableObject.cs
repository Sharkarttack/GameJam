using UnityEngine;

/// <summary> 
/// Clase base abstracta para todos los objetos interactuables del juego. 
/// Define la interfaz común que deben implementar los objetos con los que 
/// el jugador puede interactuar. 
/// </summary>
public abstract class InteractableObject : MonoBehaviour
{
    /// <summary> 
    /// Método que se ejecuta mientras el jugador interactúa con el objeto. 
    /// Debe ser implementado por todas las clases que hereden de 
    /// <see cref="InteractableObject"/> para definir su comportamiento 
    /// específico durante la interacción. 
    /// </summary>
    public abstract void OnInteract();

    /// <summary> 
    /// Indica si el objeto se encuentra actualmente seleccionado por el jugador. 
    /// Este estado puede utilizarse para habilitar o restringir acciones 
    /// durante la interacción. 
    /// </summary>
    public bool isSelected;
}
