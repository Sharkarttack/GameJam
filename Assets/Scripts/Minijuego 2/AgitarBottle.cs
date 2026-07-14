using UnityEngine;
using UnityEngine.InputSystem;

/// <summary> 
/// Gestiona el proceso de agitar el biberón. 
/// Detecta el movimiento del ratón mientras el biberón está seleccionado 
/// y, cuando se alcanza un número determinado de agitaciones, marca el 
/// contenido como correctamente mezclado.
/// </summary>
public class AgitarBottle : MonoBehaviour
{
    /// <summary>  
    /// Velocidad mínima del ratón necesaria para considerar que se está  
    /// agitando el biberón.  
    /// </summary>
    [SerializeField] private float shakeGoalSpeed;
    /// <summary> 
    /// Número de agitaciones necesarias para completar la mezcla. 
    /// </summary>
    [SerializeField] private float shakeGoalCount;
    /// <summary> 
    /// Última posición registrada del ratón. 
    /// </summary>
    Vector2 lastMousePos;
    /// <summary> 
    /// Referencia al objeto interactuable que representa el biberón. 
    /// Permite comprobar si el jugador lo tiene seleccionado. 
    /// </summary>
    [SerializeField] private InteractableObject interactableObject;
    /// <summary> 
    /// Referencia al estado actual del biberón. 
    /// </summary>
    [SerializeField] private BottleState bottleState;
    /// <summary> 
    /// Contador de agitaciones realizadas. 
    /// </summary>
    private int shakeCount;

    /// <summary> 
    /// Se ejecuta en cada actualización de física. 
    /// Comprueba si el biberón está siendo agitado y, cuando se alcanza 
    /// el número requerido de agitaciones, marca la mezcla como completada. 
    /// </summary>
    void FixedUpdate()
    {
        // Guarda la posición del ratón cuando el biberón no está seleccionado.
        if (!interactableObject.isSelected)
        {
            lastMousePos = Mouse.current.position.ReadValue();
            shakeCount = 0;
        }
        else if (bottleState.agua && bottleState.polvos && isShaking())
        {
            // Si el biberón contiene agua y polvos, comprueba si se está agitando.
            shakeCount++;
        }
        // Marca el biberón como agitado cuando se alcanza el objetivo.
        if (shakeCount >= shakeGoalCount)
        {
            bottleState.agitada = true;
        }
    }

    /// <summary> 
    /// Determina si el movimiento actual del ratón corresponde a una 
    /// agitación válida del biberón. 
    /// </summary> 
    /// <returns> 
    /// <c>true</c> si la velocidad del ratón supera el umbral establecido; 
    /// en caso contrario, <c>false</c>. 
    /// </returns>
    private bool isShaking()
    {
        // Posición actual del ratón.
        Vector2 currentPos = Mouse.current.position.ReadValue();
        // Calcula la velocidad del ratón en píxeles por segundo.
        float speed = (currentPos - lastMousePos).magnitude / Time.deltaTime;
        // Comprueba si la velocidad supera el umbral.
        if (speed > shakeGoalSpeed)
        {
            return true;
        }
        return false;
    }
}
