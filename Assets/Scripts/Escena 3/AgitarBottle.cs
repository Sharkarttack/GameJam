using UnityEngine;
using UnityEngine.InputSystem;

public class AgitarBottle : MonoBehaviour
{
    [SerializeField] private float shakeGoalSpeed;
    [SerializeField] private float shakeGoalCount;
    Vector2 lastMousePos;
    [SerializeField] private InteractableObject interactableObject;
    [SerializeField] private BottleState bottleState;
    private int shakeCount;

    void FixedUpdate()
    {
        if (!interactableObject.isSelected)
        {
            lastMousePos = Mouse.current.position.ReadValue();
        }
        else if (bottleState.agua && bottleState.polvos && isShaking())
        {
            shakeCount++;
        }
        if (shakeCount >= shakeGoalCount)
        {
            bottleState.agitada = true;
        }
    }

    private bool isShaking()
    {
        // velocity
        Vector2 currentPos = Mouse.current.position.ReadValue();
        // Velocidad del ratón en píxeles por segundo
        float speed = (currentPos - lastMousePos).magnitude / Time.deltaTime;
        if (speed > shakeGoalSpeed)
        {
           return true;
        }
        return false;
    }
}
