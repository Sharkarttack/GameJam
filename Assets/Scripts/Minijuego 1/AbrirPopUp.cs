using UnityEngine;

public class AbrirPopUp : InteractableObject
{
    [SerializeField] private CariciasManagerEscena2 cariciasManager;

    public override void OnInteract()
    {
        // Inicia el minijuego de caricias
        cariciasManager.startMimos();
        // Desactiva el collider para impedir nuevas interacciones
        gameObject.SetActive(false);
    }
}
