using UnityEngine;

public class Esconderse : MonoBehaviour
{
    [SerializeField] private Spots[] spots;
    
    void Start()
    {
        int randomNum = Random.Range(0, spots.Length);
        spots[randomNum].Escondite = true;
    }
}
