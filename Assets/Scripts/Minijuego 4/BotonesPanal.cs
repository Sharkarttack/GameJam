using System.Collections;
using UnityEngine;

public class BotonesPanal : InteractableObject
{
    [SerializeField] private InteractablePanal panal;
    int numA;
    int numD;
    public override void OnInteract()
    {
        if (panal.tipoPañal == InteractablePanal.TipoPañal.Antiguo)
        {
            numA++;
            
            if (numA >= 2)
            {
                gameObject.GetComponent<Collider2D>().enabled = false;
            }
            else
            {
                StartCoroutine(wait());
            }

            StartCoroutine(panal.Desatar());
        }
        else
        {
            if (panal.colocado)
            {
                numD++;
                StartCoroutine(wait());
                if (numD == 2)
                {
                    gameObject.GetComponent<Collider2D>().enabled = false;
                }
                panal.Atar();
            }
        }
    }

    private IEnumerator wait()
    {
        gameObject.GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(0.2f);
        gameObject.GetComponent<Collider2D>().enabled = true;
    }
}
