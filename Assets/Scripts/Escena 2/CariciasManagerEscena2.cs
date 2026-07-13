using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Gestiona el minijuego de caricias de la escena 2.
/// Controla el inicio y finalización del minijuego, el progreso del
/// jugador y la transición a la siguiente escena cuando se alcanza
/// el nivel de confianza requerido.
/// </summary>
public class CariciasManagerEscena2 : MonoBehaviour
{
    /// <summary>
    /// Indica si el minijuego de caricias se encuentra activo.
    /// </summary>
    public bool MIMOS;
    /// <summary>
    /// Ventana emergente (UI) que se muestra durante el minijuego.
    /// </summary>
    [SerializeField] private GameObject popUp;
    /// <summary>
    /// Número de caricias que el jugador debe realizar para completar
    /// una sesión del minijuego.
    /// </summary>
    [SerializeField] private int mimos_num;
    /// <summary>
    /// Referencia al objetivo interactuable que inicia el minijuego.
    /// Se utiliza para volver a habilitar su collider al finalizar.
    /// </summary>
    [SerializeField] private TargetManagerEscena2 targetManagerEscena;
    /// <summary>
    /// Contador de caricias realizadas durante la sesión actual.
    /// </summary>
    private int mimos_hechos;
    /// <summary>
    /// Número de sesiones de caricias necesarias para alcanzar la
    /// confianza suficiente y avanzar a la siguiente escena.
    /// </summary>
    [SerializeField] private int numMimosToComfianza;
    /// <summary>
    /// Número de sesiones de caricias completadas hasta el momento.
    /// </summary>
    private int numMimosToComfianza_actuales;

    /// <summary>
    /// Inicia una nueva sesión del minijuego de caricias.
    /// Incrementa el contador de sesiones, reinicia el progreso de
    /// caricias realizadas y muestra la interfaz correspondiente.
    /// </summary>
    public void startMimos()
    {
        numMimosToComfianza_actuales++;
        // Reinicia el contador de caricias
        mimos_hechos = 0;
        // Muestra la interfaz del minijuego
        popUp.SetActive(true);
        // Activa el estado del minijuego
        MIMOS = true;
    }

    /// <summary>
    /// Registra una nueva caricia realizada por el jugador.
    /// Cuando se alcanza el número de caricias requerido,
    /// el minijuego finaliza automáticamente.
    /// </summary>
    public void hacerMimos()
    {
        // Incrementa el contador de caricias realizadas.
        mimos_hechos += 1;
        // Si se alcanzó el número de caricias necesarias...
        if (mimos_hechos >= mimos_num)
        {
            // Finaliza el minijuego
            endMimos();
        }

    }

    /// <summary>
    /// Finaliza la sesión actual del minijuego.
    /// Si se ha alcanzado el número de sesiones necesarias para generar
    /// la confianza requerida, carga la escena 3. En caso contrario,
    /// restablece el estado del minijuego y vuelve a habilitar la
    /// interacción con el objetivo.
    /// </summary>    
    private void endMimos()
    {
        if (numMimosToComfianza_actuales >= numMimosToComfianza)
        {
            SceneManager.LoadScene("Escena 3");
            return;
        }
        // Reinicia el contador
        mimos_hechos = 0;
        // Oculta la interfaz del minijuego
        popUp.SetActive(false);
        // Desactiva el estado del minijuego
        MIMOS = false;
        // Vuelve a activar el collider del objetivo para que pueda
        // volver a interactuarse con él
        targetManagerEscena.GetComponent<Collider2D>().enabled = true;
    }
}
