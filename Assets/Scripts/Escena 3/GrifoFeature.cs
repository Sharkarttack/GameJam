using UnityEngine;

public class GrifoFeature : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<BottleState>() is BottleState)
        {
            other.gameObject.GetComponent<BottleState>().agua = true;
        }
    }
}
