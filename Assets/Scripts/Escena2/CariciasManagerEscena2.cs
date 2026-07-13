using UnityEngine;

public class CariciasManagerEscena2 : MonoBehaviour
{
    public bool MIMOS;
    [SerializeField] private GameObject popUp;
    [SerializeField] private int mimos_num;
    [SerializeField] private TargetManagerEscena2 targetManagerEscena;
    private int mimos_hechos;
    public void startMimos()
    {
        mimos_hechos = 0;
        popUp.SetActive(true);
        MIMOS = true;
    }
    public void hacerMimos()
    {
        mimos_hechos += 1;
        if (mimos_hechos >= mimos_num)
        {
            endMimos();
        }

    }
    private void endMimos()
    {
        mimos_hechos = 0;
        popUp.SetActive(false);
        MIMOS = false;
        targetManagerEscena.GetComponent<Collider2D>().enabled = true;
    }
}
