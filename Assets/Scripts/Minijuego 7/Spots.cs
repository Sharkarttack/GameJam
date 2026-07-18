using UnityEngine;
using UnityEngine.SceneManagement;

public class Spots : InteractableObject
{
    [SerializeField] private string nextScene;
    [SerializeField] private GameObject text;
    public bool Escondite = false;
    public override void OnInteract()
    {
        if (Escondite)
        {
            SceneManager.LoadScene(nextScene);
        }
        else
        {
            text.SetActive(true);
        }
    }
}
