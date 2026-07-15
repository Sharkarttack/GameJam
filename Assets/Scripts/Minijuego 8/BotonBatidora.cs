using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonBatidora : InteractableObject
{
    [SerializeField] private string nextScene;
    public override void OnInteract()
    {
        SceneManager.LoadScene(nextScene);
    }
}
