using UnityEngine;

/// <summary>
/// Gestiona el objetivo interactuable de la escena 2.
/// Se mueve entre distintos puntos hasta que el jugador interactúa con él.
/// </summary>
public class TargetManagerEscena2 : InteractableObject
{
    // Tiempo que debe pasar antes de cambiar de posición
    [SerializeField] private float timeToMove;
    // Lista de posiciones posibles donde puede aparecer el objetivo
    [SerializeField] private Transform[] spawnPoints;
    // Referencia al gestor del minijuego de caricias
    [SerializeField] private CariciasManagerEscena2 cariciasManager;

    [SerializeField] private GameObject newTarget;
    // Temporizador para controlar cuándo cambiar de posición
    private float time = 0;

    /// <summary>
    /// Se ejecuta una vez por frame
    /// </summary>
    void Update()
    {
        // Solo se mueve si el minijuego de caricias no está activo
        if (!cariciasManager.MIMOS)
        {
            // Incrementa el temporizador
            time += Time.deltaTime;
            // Cuando se alcanza el tiempo establecido...
            if (time >= timeToMove)
            {
                // Reinicia el temporizador
                time = 0;
                // Mueve el objetivo a otra posición
                move();
            }
        }

    }

    /// <summary>
    /// Devuelve una posición aleatoria de la lista de puntos de aparición
    /// </summary>
    /// <returns></returns>
    private Vector2 RandomPosition()
    {
        // Selecciona un índice aleatorio
        int randNum = Random.Range(0, spawnPoints.Length);
        // Devuelve la posición del punto seleccionado
        return spawnPoints[randNum].position;
    }

     /// <summary>
     /// Cambia la posición del objeto a un punto aleatorio
     /// </summary>
    private void move()
    {
        transform.position = RandomPosition();
    }

    /// <summary>
    /// Se ejecuta cuando el jugador interactúa con el objetivo
    /// </summary>
    public override void OnInteract()
    {
        newTarget.SetActive(true);
        gameObject.SetActive(false);
        /* // Inicia el minijuego de caricias
        cariciasManager.startMimos();
        // Desactiva el collider para impedir nuevas interacciones
        this.GetComponent<Collider2D>().enabled = false; */
    }
}
