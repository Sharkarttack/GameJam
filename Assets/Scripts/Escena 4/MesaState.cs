using UnityEngine;

public class MesaState : MonoBehaviour
{
    private int esquinasColocadas;
    // Update is called once per frame
    public void AddEsquina()
    {
        esquinasColocadas++;
        if (esquinasColocadas >= 4)
        {
            print("MiniGame completed");
        }
    }
}
