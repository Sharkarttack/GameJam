using UnityEngine;

/// <summary> 
/// Gestiona la interacción del biberón con el grifo. 
/// Cuando un biberón entra en el área de colisión del grifo, 
/// se marca como lleno de agua. 
/// </summary>
public class GrifoFeature : MonoBehaviour
{
    /// <summary> 
    /// Se ejecuta cuando otro objeto entra en el área de colisión del grifo. 
    /// Si el objeto dispone del componente <see cref="BottleState"/>, 
    /// se actualiza su estado para indicar que contiene agua. 
    /// </summary> 
    /// <param name="other"> 
    /// Collider del objeto que ha entrado en contacto con el grifo. 
    /// </param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<BottleState>() is BottleState)
        {
            other.gameObject.GetComponent<BottleState>().agua = true;
        }
    }
}
