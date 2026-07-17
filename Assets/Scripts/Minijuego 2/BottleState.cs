using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary> 
/// Almacena y gestiona el estado del biberón durante el minijuego. 
/// Controla si se han añadido los ingredientes necesarios y si la 
/// mezcla ha sido agitada correctamente para determinar cuándo 
/// finaliza el minijuego. 
/// </summary>
public class BottleState : MonoBehaviour
{
    [SerializeField] private string nextScene;
    [SerializeField] private Sprite sprite;
    /// <summary> 
    /// Indica si se han añadido los polvos al biberón. 
    /// </summary>
    public bool polvos;
    /// <summary> 
    /// Indica si se ha añadido agua al biberón. 
    /// </summary>
    public bool agua;
    /// <summary> 
    /// Indica si el contenido del biberón ha sido agitado correctamente. 
    /// </summary>
    public bool agitada;

    /// <summary> 
    /// Se ejecuta una vez por fotograma. 
    /// Comprueba si el biberón contiene todos los elementos necesarios 
    /// y ha sido agitado para dar por finalizado el minijuego. 
    /// </summary>
    void Update()
    {
        if (polvos && agua && agitada)
        {
            endMiniGame();
        }
        else if (polvos && agua)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
        }
    }

    /// <summary> 
    /// Finaliza el minijuego del biberón. 
    /// Actualmente muestra un mensaje en la consola indicando que el 
    /// minijuego ha terminado. 
    /// </summary>
    public void endMiniGame()
    {
        SceneManager.LoadScene(nextScene);
    }
}
