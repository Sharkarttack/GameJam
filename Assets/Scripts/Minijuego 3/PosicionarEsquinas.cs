using UnityEngine;

public class PosicionarEsquinas : MonoBehaviour
{
    [SerializeField] private Esquina.Esquinas esquinas;
    [SerializeField] private MesaState mesaState;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Esquina>() is Esquina esquina)
        {
            if (esquina.esquina == esquinas)
            {
                collision.gameObject.transform.position = transform.position;
                collision.gameObject.GetComponent<Collider2D>().enabled = false;
                mesaState.AddEsquina();
            }

        }
    }
}
