using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class InteractablePanal : InteractableObject
{
    [SerializeField] private string nextScene;
    [SerializeField] private Sprite  desatado1S;
    [SerializeField] private Sprite  desatado2S;
    [SerializeField] private Sprite atadoS;
    [SerializeField] private Sprite arrugado;
     [SerializeField] private Sprite  desatado1L;
    [SerializeField] private Sprite atadoL;
    [SerializeField] private Vector2 offset;
    int numDesatados = 0;
    int numAtados = 0;
    public enum TipoPañal { Nuevo, Antiguo }
    public TipoPañal tipoPañal;
    public bool colocado;
    [SerializeField] private Rigidbody2D rb;
    
    public override void OnInteract()
    {
        SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer>();
        // Convierte la posición del ratón (pantalla) a coordenadas del mundo
        Vector2 newPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        // Mueve el Rigidbody hasta la posición del ratón
        rb.MovePosition(newPosition+offset);
        if(tipoPañal == TipoPañal.Nuevo)
        {
            renderer.sprite = atadoL;
        }
        else 
        {
            renderer.sprite = arrugado;
        }
    }
    public IEnumerator Desatar()
    {
        SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer>();
        numDesatados++;
        renderer.sprite = desatado1S;
        if (numDesatados == 2)
        {
            renderer.sprite = desatado2S;
            yield return new WaitForSeconds(0.2f);
            gameObject.GetComponent<Collider2D>().enabled = true;
        }
    }
    public void Atar()
    {
        SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer>();
        numAtados++;
        renderer.sprite = desatado1L;
        if (numAtados == 2)
        {
            renderer.sprite = atadoL;
           SceneManager.LoadScene(nextScene);
        }
    }
}
