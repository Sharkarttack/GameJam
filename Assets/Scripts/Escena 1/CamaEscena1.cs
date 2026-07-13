
using UnityEngine.SceneManagement;

public class CamaEscena1 : InteractableObject
{
    public override void OnInteract()
    {
        print("Interacting with the bed");
        SceneManager.LoadScene("Escena 2");
    }
}
