using UnityEngine;

public class BichoCaminado : MonoBehaviour
{
    [SerializeField] private Vector2 offsetPlayerDerecha;
    [SerializeField] private Vector2 offsetPlayerIzquierda;
    public void moveBicho(float direction)
    {
        if(direction > 0)
        {
            transform.localPosition = offsetPlayerDerecha;
            gameObject.GetComponent<SpriteRenderer>().flipX = false; 
        }
        else if (direction < 0)
        {
            transform.localPosition = offsetPlayerIzquierda;
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
    }
}
