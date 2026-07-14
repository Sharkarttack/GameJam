using UnityEngine;

public class BotonesPanal : InteractableObject
{
    [SerializeField] private InteractablePanal panal;
    public override void OnInteract()
    {
        if (panal.tipoPañal == InteractablePanal.TipoPañal.Antiguo )
        {
            gameObject.GetComponent<Collider2D>().enabled = false;
            StartCoroutine(panal.Desatar());
        }
        else
        {
            if (panal.colocado)
            {
                gameObject.GetComponent<Collider2D>().enabled = false;
                panal.Atar();
            }
        }
    }
}
