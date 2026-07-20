using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonBatidora : InteractableObject
{
    [SerializeField] private string nextScene;
    public Animator batidora;
    public GameObject Agua;
    public GameObject tapa;
    public GameObject[] thoughts;
    public override void OnInteract()
    {
        StartCoroutine(interacting());
    }
    private IEnumerator interacting()
    {
        Agua.SetActive(false);
        tapa.SetActive(false);
        transform.GetChild(0).gameObject.SetActive(false);
        foreach (GameObject obj in thoughts)
        {
            obj.SetActive(false);
        }
        batidora.SetTrigger("Pulasado");
        yield return new WaitUntil(haTerminado);
        SceneManager.LoadScene(nextScene);
    }
    private bool haTerminado()
    {
        return batidora.GetCurrentAnimatorStateInfo(0).IsName("Finished");
    }
}
