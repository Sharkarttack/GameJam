using UnityEngine;

/// <summary>
/// clase que deben heredar todos los objetos interactuables
/// </summary>
public abstract class InteractableObject : MonoBehaviour
{
    /// <summary>
    /// Metodo que deben reescribir todas las clases que hereden la clase InteractableObject
    /// </summary>
    public abstract void OnInteract();

    public bool isSelected;
}
