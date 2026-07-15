using UnityEngine;

public class Batidora : MonoBehaviour
{
    int penamientosCount;
    [SerializeField] private Collider2D botonStart;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<IntrusiveThougth>() is IntrusiveThougth)
        {
            collision.gameObject.SetActive(false);
            penamientosCount++;
            if(penamientosCount >= 9)
            {
                botonStart.enabled = true;
            }
        }
    }
}
