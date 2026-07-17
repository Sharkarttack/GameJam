using UnityEngine;
using UnityEngine.SceneManagement;

public class Pomo : InteractableObject
{
   [SerializeField] private string nextScene;
   [SerializeField] private Sprite sprite;
   [SerializeField] private SpriteRenderer spriteRennerer;

   /// <summary>
    /// Sobrescribe el método de interacción definido en la clase base.
    /// </summary>
    public override void OnInteract()
    {
        spriteRennerer.sprite = sprite;
        transform.GetChild(0).gameObject.SetActive(false);
        // Carga la escena llamada "Escena 2".
        SceneManager.LoadScene(nextScene);
    }
}
