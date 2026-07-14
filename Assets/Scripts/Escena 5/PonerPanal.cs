using UnityEngine;

public class PonerPanal : MonoBehaviour
{
    [SerializeField] private Transform panalPosition;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<InteractablePanal>() is InteractablePanal panal)
        {
            if(panal.tipoPañal == InteractablePanal.TipoPañal.Nuevo)
            {
                collision.gameObject.transform.position = panalPosition.position;
                collision.enabled = false;
                panal.colocado = true;
            }
        }
    }
}
