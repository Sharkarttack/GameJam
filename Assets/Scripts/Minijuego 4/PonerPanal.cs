using UnityEngine;

public class PonerPanal : MonoBehaviour
{
    [SerializeField] private Transform panalPosition;
    [SerializeField] private Sprite desatado2L;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private InteractablePanal panal1;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<InteractablePanal>() is InteractablePanal panal)
        {
            if (panal.tipoPañal == InteractablePanal.TipoPañal.Nuevo)
            {
                spriteRenderer.sprite = desatado2L;
                panal1.UpdateLuces(Abierto2N: true);
                collision.gameObject.transform.position = panalPosition.position;
                collision.enabled = false;
                panal.colocado = true;
            }
        }
    }
}
