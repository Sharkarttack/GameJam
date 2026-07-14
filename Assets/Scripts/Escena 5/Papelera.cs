using UnityEngine;

public class Papelera : MonoBehaviour
{
    [SerializeField] private Collider2D Bicho;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<InteractablePanal>() is InteractablePanal interactablePanal)
        {
            if (interactablePanal.tipoPañal == InteractablePanal.TipoPañal.Antiguo)
            {
                interactablePanal.gameObject.SetActive(false);
                Bicho.enabled = true;
            }
        }
    }
}
