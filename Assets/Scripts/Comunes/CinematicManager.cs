using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CinematicManager : MonoBehaviour
{
    [SerializeField] private string nextScene;
    [SerializeField] private float wait = 3;
    private bool canChange = false;
    void Start()
    {
        StartCoroutine(prueba());
        StartCoroutine(CambiarEscena());
    }
    private IEnumerator CambiarEscena()
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(nextScene);
        async.allowSceneActivation = false;
        yield return new WaitUntil(CanChangeScene);
        async.allowSceneActivation = true;
    }

    private bool CanChangeScene()
    {
        return canChange;
    }
    private IEnumerator prueba()
    {
        yield return new WaitForSeconds(wait);
        canChange = true;
    }
}
