using UnityEngine;
using UnityEngine.SceneManagement;

public class Pomo : InteractableObject
{
   [SerializeField] private string nextScene;
   /// <summary>
    /// Sobrescribe el método de interacción definido en la clase base.
    /// </summary>
    public override void OnInteract()
    {
        print("TotOK");
        // Carga la escena llamada "Escena 2".
        SceneManager.LoadScene(nextScene);
    }
}
