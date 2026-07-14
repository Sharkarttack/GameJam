using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MesaState : MonoBehaviour
{
    private int esquinasColocadas;
    // Update is called once per frame
    public void AddEsquina()
    {
        esquinasColocadas++;
        if (esquinasColocadas >= 4)
        {
            SceneManager.LoadScene("Escena 5");
        }
    }
}
