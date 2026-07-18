using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public void SalirDelJuego()
    {
        Application.Quit();
        
        // Si estás probando en el Editor de Unity, esto detiene el modo juego
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
