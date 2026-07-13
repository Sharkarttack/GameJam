using UnityEngine;

/// <summary>
/// Gestiona el minijuego de caricias de la escena 2.
/// </summary>
public class CariciasManagerEscena2 : MonoBehaviour
{
    // Indica si el minijuego de caricias está activo
    public bool MIMOS;
    // Ventana emergente (UI) que aparece durante el minijuego
    [SerializeField] private GameObject popUp;
    // Número de caricias necesarias para completar el minijuego
    [SerializeField] private int mimos_num;
    // Referencia al objetivo interactuable
    [SerializeField] private TargetManagerEscena2 targetManagerEscena;
    // Contador de caricias realizadas
    private int mimos_hechos;

    /// <summary>
    /// Inicia el minijuego
    /// </summary>
    public void startMimos()
    {
        // Reinicia el contador de caricias
        mimos_hechos = 0;
        // Muestra la interfaz del minijuego
        popUp.SetActive(true);
        // Activa el estado del minijuego
        MIMOS = true;
    }

    /// <summary>
    /// Se llama cada vez que el jugador realiza una caricia
    /// </summary>
    public void hacerMimos()
    {
        // Incrementa el contador
        mimos_hechos += 1;
        // Si se alcanzó el número de caricias necesarias...
        if (mimos_hechos >= mimos_num)
        {
            // Finaliza el minijuego
            endMimos();
        }

    }

    /// <summary>
    /// Finaliza el minijuego
    /// </summary>
    private void endMimos()
    {
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
