using UnityEngine;

public class PonerPanal : MonoBehaviour
{
    [SerializeField] private Transform panalPosition;
    [SerializeField] private Sprite desatado2L;
    [SerializeField] private SpriteRenderer renderer;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<InteractablePanal>() is InteractablePanal panal)
        {
            if (panal.tipoPañal == InteractablePanal.TipoPañal.Nuevo)
            {
                renderer.sprite = desatado2L;
                collision.gameObject.transform.position = panalPosition.position;
                collision.enabled = false;
                panal.colocado = true;
            }
        }
    }
}
