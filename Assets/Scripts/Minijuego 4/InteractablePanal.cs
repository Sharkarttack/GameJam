using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class InteractablePanal : InteractableObject
{
    [SerializeField] private string nextScene;
    [SerializeField] private GameObject  LuzCerradoS;
    [SerializeField] private GameObject  LuzCerradoN;
    [SerializeField] private GameObject  LuzAbierto1S;
    [SerializeField] private GameObject  LuzAbierto1N;
    [SerializeField] private GameObject  LuzAbierto2S;
    [SerializeField] private GameObject  LuzAbierto2N;
    [SerializeField] private GameObject  LuzArrugado;
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
            UpdateLuces(CerradoN: true);
        }
        else 
        {
            renderer.sprite = arrugado;
            UpdateLuces(Arrugado: true);
        }
    }
    public IEnumerator Desatar()
    {
        SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer>();
        numDesatados++;
        renderer.sprite = desatado1S;
        UpdateLuces(Abierto1S: true);
        if (numDesatados == 2)
        {
            renderer.sprite = desatado2S;
            UpdateLuces(Abierto2S: true);
            yield return new WaitForSeconds(0.2f);
            gameObject.GetComponent<Collider2D>().enabled = true;
        }
    }
    public void Atar()
    {
        SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer>();
        numAtados++;
        renderer.sprite = desatado1L;
        UpdateLuces(Abierto1N: true);
        if (numAtados == 2)
        {
            renderer.sprite = atadoL;
            UpdateLuces(CerradoN: false);
           SceneManager.LoadScene(nextScene);
        }
    }

    public void UpdateLuces(bool Arrugado = false, bool CerradoS = false, bool CerradoN = false, bool Abierto1N = false, bool Abierto1S = false, bool Abierto2N = false, bool Abierto2S = false)
    {
        if(tipoPañal == TipoPañal.Nuevo)
        {
            LuzAbierto1N.SetActive(Abierto1N);
            LuzAbierto2N.SetActive(Abierto2N);
            LuzCerradoN.SetActive(CerradoN);
        }
        else
        {
            LuzAbierto1S.SetActive(Abierto1S);
            LuzAbierto2S.SetActive(Abierto2S);
            LuzCerradoS.SetActive(CerradoS);
            LuzArrugado.SetActive(Arrugado);
        }
    }
}
