using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MesaState : MonoBehaviour
{
    [SerializeField] private string nextScene;
    private int esquinasColocadas;
    // Update is called once per frame
    public void AddEsquina()
    {
        esquinasColocadas++;
        if (esquinasColocadas >= 4)
        {
            SceneManager.LoadScene(nextScene);
        }
    }
}
