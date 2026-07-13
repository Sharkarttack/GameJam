using UnityEngine;

public class BottleState : MonoBehaviour
{
    public bool polvos;
    public bool agua;
    public bool agitada;

    void Update()
    {
        if (polvos && agua && agitada)
        {
            endMiniGame();
        }
    }
    public void endMiniGame()
    {
        print("miniGame ended");
    }
}
