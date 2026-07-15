using UnityEngine;
using UnityEngine.SceneManagement;

public class Spots : InteractableObject
{
    [SerializeField] private string nextScene;
    public bool Escondite = false;
    public override void OnInteract()
    {
        if (Escondite)
        {
            SceneManager.LoadScene(nextScene);
        }
        else
        {
            print("no parece estar aqui");
        }
    }
}
