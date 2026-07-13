using UnityEngine;
using UnityEngine.InputSystem;

public class PopUpCariciasEscena2 : InteractableObject
{
    [SerializeField] private CariciasManagerEscena2 cariciasManager;
    public override void OnInteract()
    {
        cariciasManager.hacerMimos();
    }
}
