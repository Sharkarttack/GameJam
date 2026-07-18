using UnityEngine;
using System.Collections.Generic;

public class Batidora : MonoBehaviour
{
    public bool Agua = false;
    public bool Thoughts = false;
    public bool Tapa = false;
    int penamientosCount;
    [SerializeField] private Collider2D botonStart;
    public GameObject aguaGameObject;
    public List<Transform> newPosition;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<IntrusiveThougth>() is IntrusiveThougth intrusive)
        {
            collision.enabled = false;
            intrusive.Posicionar(newPosition[0]);
            newPosition.RemoveAt(0);
            penamientosCount++;
            if (penamientosCount >= 9)
            {
                Thoughts = true;
            }
        }
        else if (collision.gameObject.GetComponent<Tapa>() is Tapa tapa)
        {
            if (Agua && Thoughts)
            {
                tapa.Posicionar();
                Tapa = true;
            }
        }
    }
    void Update()
    {
        if (Agua && Thoughts && Tapa)
        {
            botonStart.enabled = true;
        }
        else if (Agua)
        {
            aguaGameObject.SetActive(true);
        }
    }
}
